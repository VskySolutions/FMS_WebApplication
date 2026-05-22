using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Vsky.Models;

namespace Vsky.Services.Users
{
    public class UserService : IUserService
    {
        #region Fields

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        #endregion

        #region Ctor

        public UserService(UserManager<ApplicationUser> userManager,
            IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion

        #region Methods

        public async Task<string> GetUserInitialAsync()
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

            var name = $"{user.FirstName} {user.LastName}";

            var list = name.Split(new string[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries);

            var initials = "";

            foreach (var item in list)
            {
                initials += item[..1].ToUpper();
            }

            return initials;
        }

        public async Task<IList<ApplicationUser>> GetAdminUsersAsync()
        {
            return (await _userManager.GetUsersInRoleAsync(Roles.Administrator)).Where(x => !x.Deleted).ToList();
        }

        public async Task<IList<ApplicationUser>> GetUsersAsync()
        {
            return (await _userManager.GetUsersInRoleAsync(Roles.Employee)).Where(x => !x.Deleted).ToList();
        }

        public async Task<IList<ApplicationUser>> GetSystemUsersAsync(List<string> userIds = null)
        {
            var query = (await _userManager.GetUsersInRoleAsync(Roles.SystemUser)).Where(x => !x.Deleted);

            if (userIds != null && userIds.Any())
                query = query.Where(x => userIds.Contains(x.Id));

            return query.ToList();
        }

        public async Task<IList<ApplicationUser>> GetInstructorsAsync(List<string> userIds = null)
        {
            var query = (await _userManager.GetUsersInRoleAsync(Roles.Instructor)).Where(x => !x.Deleted);

            if (userIds != null && userIds.Any())
                query = query.Where(x => userIds.Contains(x.Id));

            return query.ToList();
        }

        public Task<string> GetUserFullNameAsync(ApplicationUser user)
        {
            var fullName = string.Empty;

            if (!string.IsNullOrWhiteSpace(user.FirstName) && !string.IsNullOrWhiteSpace(user.LastName))
            {
                fullName = $"{user.FirstName} {user.LastName}";
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(user.FirstName))
                {
                    fullName = user.FirstName;
                }

                if (!string.IsNullOrWhiteSpace(user.LastName))
                {
                    fullName = user.LastName;
                }
            }

            return Task.FromResult(fullName);
        }

        public string GeneratePassword()
        {
            var options = _userManager.Options.Password;

            var length = options.RequiredLength;

            //var nonAlphanumeric = options.RequireNonAlphanumeric;
            var digit = options.RequireDigit;
            var lowercase = options.RequireLowercase;
            var uppercase = options.RequireUppercase;

            var password = new StringBuilder();
            var random = new Random();

            while (password.Length < length)
            {
                var c = (char)random.Next(32, 126);

                if (char.IsLetterOrDigit(c))
                {
                    password.Append(c);

                    if (char.IsDigit(c))
                    {
                        password.Append(c);
                    }

                    if (char.IsDigit(c))
                    {
                        digit = false;
                    }
                    else if (char.IsLower(c))
                    {
                        lowercase = false;
                    }
                    else if (char.IsUpper(c))
                    {
                        uppercase = false;
                    }
                    //else if (!char.IsLetterOrDigit(c))
                    //{
                    //    nonAlphanumeric = false;
                    //}
                }
            }

            //if (nonAlphanumeric)
            //{
            //    password.Append((char)random.Next(33, 48));
            //}

            if (digit)
            {
                password.Append((char)random.Next(48, 58));
            }

            if (lowercase)
            {
                password.Append((char)random.Next(97, 123));
            }

            if (uppercase)
            {
                password.Append((char)random.Next(65, 91));
            }

            return password.ToString();
        }

        #endregion
    }
}