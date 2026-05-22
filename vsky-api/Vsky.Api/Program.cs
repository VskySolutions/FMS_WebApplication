using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NPOI.SS.Formula.Functions;
using StackExchange.Profiling;
using Swashbuckle.AspNetCore.SwaggerUI;
using Vsky.Api.ApiErrors;
using Vsky.Api.Converter;
using Vsky.Api.Extensions;
using Vsky.Core.Configuration;
using Vsky.Core.Infrastructure;
using Vsky.Data;
using Vsky.Models;
using Vsky.Services.Common;
using Vsky.Services.Configuration;
using Vsky.Services.DropDowns;
using Vsky.Services.Logging;
using Vsky.Services.Menus;
using Vsky.Services.Messages;
using Vsky.Services.Security;
using Vsky.Services.Users;

namespace Vsky.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Environment.SetEnvironmentVariable("PLAYWRIGHT_BROWSERS_PATH", "C:\\Users\\admin\\AppData\\Local\\ms-playwright\\");
            Environment.SetEnvironmentVariable("PLAYWRIGHT_BROWSERS_PATH", "C:\\Users\\Administrator\\AppData\\Local\\ms-playwright\\");

            var builder = WebApplication.CreateBuilder(args);

            // add services to the container
            var mvcBuilder = builder.Services.AddControllers(options =>
            {
                options.MaxModelValidationErrors = 50;
            });

            // Configure FormOptions to increase the form value limit
            builder.Services.Configure<FormOptions>(options =>
            {
                options.ValueCountLimit = 50000; // Adjust this value based on your requirements
            });


            // Add CORS services
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigins",
                    builder =>
                    {
                        builder.WithOrigins("https://hlda.vskyapplications.com", "https://uathlda.vskyapplications.com", "http://localhost:9000") // Specify allowed origins
                               .AllowAnyHeader()   // Allow any headers (for access to images)
                               .AllowAnyMethod()   // Allow any HTTP methods (GET, POST, etc.)
                               .AllowCredentials(); // Allow cookies and credentials if needed
                    });
            });

            mvcBuilder.AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                options.JsonSerializerOptions.Converters.Add(new CustomDateTimeConverter());
            });

            // configure invalid model error model and formats
            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (actionContext) => new BadRequestObjectResult(new ValidationError(actionContext.ModelState));
            });

            // add fluent validation
            builder.Services.AddFluentValidationAutoValidation();

            // register all available validators from vsky assemblies
            var assemblies = mvcBuilder.PartManager.ApplicationParts
                .OfType<AssemblyPart>()
                .Where(part => part.Name.StartsWith("Vsky", StringComparison.InvariantCultureIgnoreCase))
                .Select(part => part.Assembly);

            builder.Services.AddValidatorsFromAssemblies(assemblies);

            // db context
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                options.EnableSensitiveDataLogging();
            });

            // configure the data protection system to persist keys to the specified directory
            var dataProtectionKeysFolder = new DirectoryInfo("App_Data/DataProtectionKeys");
            builder.Services.AddDataProtection().PersistKeysToFileSystem(dataProtectionKeysFolder);

            // add identity
            builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequiredLength = 5;
                options.SignIn.RequireConfirmedAccount = true;
            }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            // identity options
            builder.Services.Configure<IdentityOptions>(options =>
            {
                // password settings
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                // user settings
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;

                // sign in
                options.SignIn.RequireConfirmedEmail = true;
            });

            // jwt token config
            var jwtTokenConfig = builder.Configuration.GetSection("JwtTokenConfig").Get<JwtTokenConfig>();
            builder.Services.AddSingleton(jwtTokenConfig);

            // add authentication
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = jwtTokenConfig.Issuer,
                    ValidAudience = jwtTokenConfig.Audience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtTokenConfig.SecurityKey)),
                    ClockSkew = TimeSpan.Zero,
                    RequireExpirationTime = true,
                    RequireSignedTokens = true,
                    NameClaimType = JwtRegisteredClaimNames.Sub
                };
                cfg.Events = new JwtBearerEvents
                {
                    OnTokenValidated = async ctx =>
                    {
                        var user = (ApplicationUser)null;

                        if (ctx.SecurityToken is JwtSecurityToken accessToken)
                        {
                            var subClaim = ctx.Principal.FindFirst(ClaimTypes.NameIdentifier);
                            var roleClaim = ctx.Principal.FindFirst(ClaimTypes.Role);

                            if (subClaim != null && roleClaim != null)
                            {
                                var userManager = ctx.HttpContext.RequestServices.GetRequiredService<UserManager<ApplicationUser>>();

                                if (userManager != null)
                                {
                                    user = await userManager.GetUserAsync(ctx.Principal);
                                }
                            }
                        }

                        if (user == null || !user.Active || user.Deleted)
                        {
                            ctx.Fail("No active user account found.");
                        }
                    },
                    OnAuthenticationFailed = async ctx =>
                    {
                        ctx.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        ctx.Response.ContentType = "application/json";

                        var error = new AuthError(StatusCodes.Status401Unauthorized, "An error occurred processing your authentication.");
                        await System.Text.Json.JsonSerializer.SerializeAsync(ctx.Response.Body, error);
                        await ctx.Response.Body.FlushAsync();
                    }
                };
            });

            // mini profiler
            if (builder.Environment.IsDevelopment())
            {
                builder.Services.AddMiniProfiler(options =>
                {
                    options.RouteBasePath = "/profiler";
                    options.IgnoredPaths.Add("/swagger");
                    options.ResultsAuthorize = request => IsUserAuthorized(request);
                    options.ResultsListAuthorize = request => IsUserAuthorized(request);
                    options.ShouldProfile = request => ShouldProfile(request);
                    options.ColorScheme = ColorScheme.Dark;
                }).AddEntityFramework();
            }

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            builder.Services.AddResponseCompression();

            ServicePointManager.SecurityProtocol = SecurityProtocolType.SystemDefault;

            // services
            builder.Services.AddScoped<IAppFileProvider, AppFileProvider>();
            builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            builder.Services.AddScoped<ILogger, DefaultLogger>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IWorkflowMessageService, WorkflowMessageService>();
            builder.Services.AddScoped<ISmtpBuilder, SmtpBuilder>();
            builder.Services.AddScoped<IEmailSender, EmailSender>();
            builder.Services.AddScoped<IEmailAccountService, EmailAccountService>();
            builder.Services.AddScoped<ITokenizer, Tokenizer>();
            builder.Services.AddScoped<IMessageTokenProvider, MessageTokenProvider>();
            builder.Services.AddScoped<ICommonService, CommonService>();
            builder.Services.AddScoped<IConfigurationService, ConfigurationService>();
            builder.Services.AddScoped<IDropDownService, DropDownService>();
            builder.Services.AddScoped<IEncryptionService, EncryptionService>();

            builder.Services.AddScoped<IMenuService, MenuService>();
            builder.Services.AddScoped<IMenuPermissionService, MenuPermissionService>();
            builder.Services.AddScoped<IApplicationUserInfoService, ApplicationUserInfoService>();
            builder.Services.AddScoped<IApplicationUserParentService, ApplicationUserParentService>();

            builder.Services.ConfigureCors();
            builder.Services.ConfigureIISIntegration();

            builder.Services.AddAutoMapper(typeof(Program).Assembly);

            builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "HLDA Application", Version = "v1" }));
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "FMS Solutions APIs",
                    Version = "v1"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    //Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter your token in the text input below.\r\n\r\nExample: \"1safsfsdfdfd\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme {
                        Reference = new OpenApiReference {
                            Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                        }
                    },
                    new string[] {}
                }
                });
            });

            var app = builder.Build();

            // Enable CORS in the request pipeline
            app.UseCors("AllowSpecificOrigins");

            app.UseDeveloperExceptionPage();

            // configure the http request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseMiniProfiler();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    var path = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
                    c.SwaggerEndpoint($"{path}/swagger/v1/swagger.json", "FMS Solutions v1");
                    c.DocExpansion(DocExpansion.None);
                });
            }
            else
            {
                app.MapGet("/", () => "FMS Solutions");
            }

            // configure the http request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseResponseCompression();

            app.UseExceptionHandler(handler =>
            {
                handler.Run(async ctx =>
                {
                    var exception = ctx.Features.Get<IExceptionHandlerFeature>()?.Error;

                    if (exception == null)
                    {
                        return;
                    }

                    var logId = string.Empty;

                    try
                    {
                        var logger = ctx.RequestServices.GetRequiredService<ILogger>();

                        logId = logger?.Error(exception.Message, exception);
                    }
                    finally
                    {
                        ctx.Response.ContentType = "application/json";
                        ctx.Response.StatusCode = StatusCodes.Status500InternalServerError;

                        var error = new AuthError(StatusCodes.Status401Unauthorized, $"An error occurred while processing your request. Reference id is {logId}");
                        await System.Text.Json.JsonSerializer.SerializeAsync(ctx.Response.Body, error);
                        await ctx.Response.Body.FlushAsync();
                    }
                });
            });

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        public static bool IsUserAuthorized(HttpRequest request)
        {
            return request.HttpContext.User.Identity.IsAuthenticated;
        }

        public static bool ShouldProfile(HttpRequest request)
        {
            return request.HttpContext.User.Identity.IsAuthenticated;
        }
    }
}