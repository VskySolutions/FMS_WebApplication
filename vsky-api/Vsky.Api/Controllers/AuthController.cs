using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Vsky.Api.ApiErrors;
using Vsky.Api.Models;
using Vsky.Core.Configuration;
using Vsky.Models;
using Vsky.Services.Messages;
using Vsky.Services.Users;

namespace Vsky.Api.Controllers
{
    [Route("auth")]
    public class AuthController : BaseController
    {
        #region Fields

        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtTokenConfig _jwtTokenConfig;
        private readonly IWorkflowMessageService _workflowMessageService;
        private readonly IUserService _userService;

        #endregion

        #region Ctor

        public AuthController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager,
            JwtTokenConfig jwtTokenConfig, IWorkflowMessageService workflowMessageService, IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtTokenConfig = jwtTokenConfig;
            _workflowMessageService = workflowMessageService;
            _userService = userService;
        }

        #endregion

        #region Utilities

        private static long ToUnixEpochDate(DateTime date)
        {
            return (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
        }

        private static string GenerakeToken(ApplicationUser user, JwtTokenConfig jwtTokenConfig, IList<string> roles)
        {
            // default claims
            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, user.Id),
                new(JwtRegisteredClaimNames.UniqueName, user.UserName),
                new(JwtRegisteredClaimNames.Jti, jwtTokenConfig.JtiGenerator().Result),
                new(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(jwtTokenConfig.IssuedAt).ToString(), ClaimValueTypes.Integer64),
                new(JwtRegisteredClaimNames.Email, user.Email),
                new(JwtRegisteredClaimNames.Iss, jwtTokenConfig.Issuer),
            };

            // user roles as claims
            claims.AddRange(roles.Select(x => new Claim(ClaimTypes.Role, x)));

            // the jwt security token and encode it
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtTokenConfig.SecurityKey));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                issuer: jwtTokenConfig.Issuer,
                audience: jwtTokenConfig.Audience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: jwtTokenConfig.Expiration,
                signingCredentials: signinCredentials);

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }

        #endregion

        #region Methods

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(TokenModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.FindByNameAsync(model.Username);

                    if (user != null && !user.Deleted && user.Active)
                    {
                        var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, true);
                        
                        if (result.Succeeded)
                        {
                            var roles = await _userManager.GetRolesAsync(user);
                            var token = GenerakeToken(user, _jwtTokenConfig, roles);

                            var tokenResult = new TokenResultModel
                            {
                                Token = token,
                                ExpiresIn = (int)_jwtTokenConfig.ValidFor.TotalSeconds,
                                CreatedAt = DateTime.UtcNow,
                                UserId = user.Id,
                                Username = user.UserName,
                                FirstName = user.FirstName,
                                LastName = user.LastName,
                                Email = user.Email,
                                ProfilePictureId = user.ProfilePictureId
                            };

                            if (roles != null && roles.Count > 0)
                            {
                                tokenResult.Roles = roles.Select(x => x.ToLower()).ToArray();
                            }

                            return Ok(tokenResult);
                        }
                        else if (result.RequiresTwoFactor)
                        {
                            await _signInManager.SignOutAsync();

                            var code = await _userManager.GenerateTwoFactorTokenAsync(user, "Email");

                            // send two factor code email
                            await _workflowMessageService.SendTwoFactorToken(user, code);

                            // redirect to login with 2fa
                            return Ok(new AuthError((int)AuthErrorCodes.RequiresTwoFactor, user.Email));

                        }
                        else if (result.IsLockedOut)
                        {
                            // redirect to lockout
                            return Ok(new AuthError((int)AuthErrorCodes.Lockedout, "User account locked out."));
                        }
                        else
                        {
                            return BadRequest(new BadRequestError("Invalid login attempt."));
                        }
                    }
                }

            }
            catch (Exception ex)
            {   
                return BadRequest(ex.Message);
            }

            return BadRequest(new BadRequestError("Invalid login attempt."));
        }

        [HttpPost("forgot-password")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user == null || user.Deleted || !(await _userManager.IsEmailConfirmedAsync(user)))
                {
                    return BadRequest(new BadRequestError("No user was found with the specified id."));
                }

                var password = _userService.GeneratePassword();

                var code = await _userManager.GeneratePasswordResetTokenAsync(user);

                var result = await _userManager.ResetPasswordAsync(user, code, password);

                if (result.Succeeded)
                {
                    await _workflowMessageService.SendResetPasswordEmail(user, password);

                    return Ok("Your password has been reset, and a new password has been sent to your email.");
                }
                else
                {
                    return InternalServerError(result.Errors);
                }
            }

            return ModelStateError(ModelState);
        }

        #endregion
    }
}