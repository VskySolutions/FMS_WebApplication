using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Vsky.Api.ApiErrors;
using Vsky.Api.Extensions;
using Vsky.Api.Models;
using Vsky.Data;
using Vsky.Models;
using Vsky.Services.Messages;
using Vsky.Services.Users;
using static Vsky.Api.Models.ApplicationUserInfoModel;
using static Vsky.Api.Models.DropDownModel;

namespace Vsky.Api.Controllers
{
    [Route("users")]
    public class UsersController : BaseController
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IWorkflowMessageService _workflowMessageService;
        private readonly IUserService _userService;

        #endregion

        #region Ctor

        public UsersController(IMapper mapper, ApplicationDbContext db, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager,
            IWorkflowMessageService workflowMessageService, IUserService userService)
        {
            _mapper = mapper;
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
            _workflowMessageService = workflowMessageService;
            _userService = userService;
        }

        #endregion

        #region Methods

        [HttpGet]
        public async Task<IActionResult> GetUsers([FromQuery] ApplicationUserSearchModel searchModel)
        {
            var query = _userManager.Users.Where(x => !x.Deleted && x.UserRoles.Any(m => m.Role.Name != "SuperAdmin"));

            if(searchModel.SortBy!=null && searchModel.SortBy != "")
                query = query.OrderByDescending(x => x.CreatedOnUtc);
            else
                query = query.OrderBy(x => x.FirstName);

            query = query.Select(x => new ApplicationUser
            {
                Id = x.Id,
                UserName = x.UserName,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Active = x.Active,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                UserRoles = x.UserRoles.Select(mapping => new ApplicationUserRole
                {
                    Role = mapping.Role
                }).ToList()
            });

            var list = await query.ToListAsync();

            var model = _mapper.Map<IList<UserModel>>(list);

            return Ok(model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null || user.Deleted)
            {
                return BadRequest(new BadRequestError("No user was found with the specified id."));
            }


            //var role = user.UserRoles?.FirstOrDefault();
            //var model = _mapper.Map<UserModel>(user);
            //model.RoleId = role?.Id;

            var roleNames = await _userManager.GetRolesAsync(user);
            var role = _roleManager.Roles.Where(x => roleNames.AsEnumerable().Contains(x.Name)).FirstOrDefault();
            var roleId = role != null ? role.Id : "";

            var model = _mapper.Map<UserModel>(user);
            model.RoleId = roleId;

            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserModel model)
        {
            if (ModelState.IsValid)
            {
                var loggedUserId = User.GetLoggedInUserId<string>();
                var loggedUser = await _userManager.FindByIdAsync(loggedUserId);

                var user = _mapper.Map<ApplicationUser>(model);

                var exists = await _userManager.Users.AnyAsync(x => x.UserName == model.Username && !x.Deleted);

                if (exists)
                {
                    return BadRequest(new BadRequestError("Username already exists. Please try a different one."));
                }

                if (_userManager.Options.User.RequireUniqueEmail)
                {
                    exists = await _userManager.Users.AnyAsync(x => x.Email == model.Email && !x.Deleted);

                    if (exists)
                    {
                        return BadRequest(new BadRequestError("Email already exists. Please try a different one."));
                    }
                }

                user.Id = Guid.NewGuid().ToString();
                user.EmailConfirmed = true;
                user.PhoneNumberConfirmed = true;
                user.TwoFactorEnabled = false;
                user.UpdatedById = User.GetLoggedInUserId<string>();
                user.UpdatedOnUtc = DateTime.UtcNow;

                var password = (model.Password != "" || model.Password != null) ? model.Password : _userService.GeneratePassword();

                var result = await _userManager.CreateAsync(user, password);

                if (result.Succeeded)
                {
                    var role = await _roleManager.FindByIdAsync(model.RoleId);

                    if (role != null)
                    {
                        await _userManager.AddToRoleAsync(user, role.Name);
                    }
                    else
                    {
                        role = await _roleManager.FindByNameAsync(Roles.SystemUser);

                        await _userManager.AddToRoleAsync(user, role.Name);
                    }

                    // send a mail to the user with the username and temp password
                    //await _workflowMessageService.SendWelcomeEmail(user, password);

                    return Ok(new { password });
                }
                else
                {
                    return InternalServerError(result.Errors);
                }
            }

            return ModelStateError(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] UserModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(id);

                if (user == null || user.Deleted)
                {
                    return BadRequest(new BadRequestError("No user was found with the specified id."));
                }

                user.UserName = model.Username;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;
                user.Active = model.Active;
                user.UpdatedById = User.GetLoggedInUserId<string>();
                user.UpdatedOnUtc = DateTime.UtcNow;

                var result = await _userManager.UpdateAsync(user);                

                if(model.Password != "" && model.Password != null)
                {
                    var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                    await _userManager.ResetPasswordAsync(user, code, model.Password);
                }                    

                if (result.Succeeded)
                {
                    var role = await _roleManager.FindByIdAsync(model.RoleId);

                    //Remove previous assigned role
                    var prevRoleName = "";
                    var previousRoles = await _userManager.GetRolesAsync(user);
                    if(previousRoles.Count()>0)
                    {
                        prevRoleName = previousRoles[0];                       
                    }

                    if (role != null)
                    {   
                        if (role.Name != prevRoleName)
                        {
                            //Removed assigned Role
                            await _userManager.RemoveFromRoleAsync(user, prevRoleName);

                            //Assign Role
                            await _userManager.AddToRoleAsync(user, role.Name);
                        }                       
                    }     

                    return NoContent();
                }
                else
                {
                    return InternalServerError(result.Errors);
                }
            }

            return ModelStateError(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null || user.Deleted)
            {
                return BadRequest(new BadRequestError("No user was found with the specified id."));
            }

            user.Deleted = true;
            user.Active = false;

            user.UpdatedById = User.GetLoggedInUserId<string>();
            user.UpdatedOnUtc = DateTime.UtcNow;

            var userCount = _userManager.Users.Count(x => x.UserName.StartsWith(user.UserName + "_deleted"));
            var emailCount = _userManager.Users.Count(x => x.Email.StartsWith(user.Email + "_deleted"));

            // update username, email
            user.UserName += "_deleted_" + userCount;
            user.Email += "_deleted_" + emailCount;

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return NoContent();
            }
            else
            {
                return InternalServerError(result.Errors);
            }
        }

        [HttpPost("{id}/reset-password")]
        public async Task<IActionResult> ResetPassword(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null || user.Deleted)
            {
                return BadRequest(new BadRequestError("No user was found with the specified id."));
            }

            var password = _userService.GeneratePassword();

            var code = await _userManager.GeneratePasswordResetTokenAsync(user);

            var result = await _userManager.ResetPasswordAsync(user, code, password);

            if (result.Succeeded)
            {
                await _workflowMessageService.SendResetPasswordEmail(user, password);

                return Ok(new { password });
            }
            else
            {
                return InternalServerError(result.Errors);
            }
        }

        [HttpPost("{id}/send-user-login")]
        public async Task<IActionResult> SendUserLoginDetails(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null || user.Deleted)
                return BadRequest(new BadRequestError("No user was found with the specified id."));

            var password = _userService.GeneratePassword();
            var code = await _userManager.GeneratePasswordResetTokenAsync(user);

            var result = await _userManager.ResetPasswordAsync(user, code, password);
            if (result.Succeeded)
            {
                await _workflowMessageService.SendWelcomeEmail(user, password);

                return Ok(new { password });
            }
            else
            {
                return InternalServerError(result.Errors);
            }
        }

        [HttpGet("saveInstructors")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUserInstructor()
        {
            string HLDACompanyId = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["HLDA_Company_ID"];

            var userModel = new UserModel();

            return ModelStateError(ModelState);
        }

        #endregion
    }
}