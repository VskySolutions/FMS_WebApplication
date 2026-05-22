using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vsky.Api.ApiErrors;
using Vsky.Api.Extensions;
using Vsky.Api.Models;
using Vsky.Data;
using Vsky.Models;
using Vsky.Services.Messages;
using Vsky.Services.Common;
using Vsky.Services.Users;


namespace Vsky.Api.Controllers
{
    [Route("account")]
    public class AccountController : BaseController
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IUserService _userService;
        private readonly ICommonService _commonService;

        #endregion

        #region Ctor

        public AccountController(IMapper mapper, ApplicationDbContext db, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager,
            IUserService userService, ICommonService commonService)
        {
            _mapper = mapper;
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
            _userService = userService;
            _commonService = commonService;
        }

        #endregion

        #region Methods

        [HttpGet("profile")]
        public async Task<IActionResult> GetUserProfile()
        {
            var loggedUserId = User.GetLoggedInUserId<string>();
            var loggedUser = await _userManager.FindByIdAsync(loggedUserId);

            if (loggedUser == null || loggedUser.Deleted)
            {
                return BadRequest(new BadRequestError("No user was found with the specified id."));
            }

            var model = _mapper.Map<UserModel>(loggedUser);

            return Ok(model);
        }

        [HttpPost("profile")]
        public async Task<IActionResult> UpdateUser([FromForm] UserModel model)
        {
            if (ModelState.IsValid)
            {
                var loggedUserId = User.GetLoggedInUserId<string>();
                var loggedUser = await _userManager.FindByIdAsync(loggedUserId);

                if (loggedUser == null || loggedUser.Deleted)
                {
                    return BadRequest(new BadRequestError("No user was found with the specified id."));
                }

                var user = _mapper.Map(model, loggedUser);
                user.UpdatedById = User.GetLoggedInUserId<string>();
                user.UpdatedOnUtc = DateTime.UtcNow;

                if (model.ChangeFlag == "edit")
                {
                    if (model.File != null && model.File.Length > 0)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            await model.File.CopyToAsync(memoryStream);
                            var newLogoImageData = memoryStream.ToArray();

                            var picture = new Picture
                            {
                                SeoFilename = model.Filename + ".jpg",
                                MimeType = "image"
                            };
                            _commonService.InsertPicture(picture);

                            var pictureBinary = new PictureBinary
                            {
                                PictureId = picture.Id,
                                BinaryData = newLogoImageData
                            };
                            _commonService.InsertPictureBinary(pictureBinary);

                            user.ProfilePictureId = picture.Id;                            
                        }
                    }
                }
                else if (model.ChangeFlag == "remove")
                {
                    // Remove the logo file
                    user.ProfilePictureId = null;
                }

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return Ok(user);
                    //return NoContent();
                }
                else
                {
                    return InternalServerError(result.Errors);
                }
            }

            return ModelStateError(ModelState);
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        {
            var loggedUserId = User.GetLoggedInUserId<string>();
            var loggedUser = await _userManager.FindByIdAsync(loggedUserId);

            if (loggedUser == null || loggedUser.Deleted)
            {
                return BadRequest(new BadRequestError("No user was found with the specified id."));
            }

            if (model.NewPassword != model.ConfirmPassword)
            {
                return BadRequest(new BadRequestError("New password should match confirm password."));
            }
            
            // ChangePasswordAsync changes the user password
            var result = await _userManager.ChangePasswordAsync(loggedUser, model.OldPassword, model.NewPassword);

            //var password = _userService.GeneratePassword();
            //var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            //var result = await _userManager.ResetPasswordAsync(user, code, password);

            if (result.Succeeded)
            {
                //await _workflowMessageService.SendResetPasswordEmail(user, password);

                return Ok();
            }
            else
            {
                return InternalServerError(result.Errors);
            }
        }


        #endregion
    }
}