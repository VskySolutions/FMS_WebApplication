using System.Collections.Generic;
using System.Threading.Tasks;
using Vsky.Models;

namespace Vsky.Services.Users
{
    public interface IUserService
    {
        Task<string> GetUserInitialAsync();

        Task<IList<ApplicationUser>> GetAdminUsersAsync();

        Task<IList<ApplicationUser>> GetUsersAsync();

        Task<IList<ApplicationUser>> GetSystemUsersAsync(List<string> userIds = null);

        Task<IList<ApplicationUser>> GetInstructorsAsync(List<string> userIds = null);

        Task<string> GetUserFullNameAsync(ApplicationUser user);

        string GeneratePassword();
    }
}