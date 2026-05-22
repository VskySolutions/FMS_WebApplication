using System.Collections.Generic;
using System.Threading.Tasks;
using Vsky.Core;
using Vsky.Models;

namespace Vsky.Services.Users
{
    public interface IApplicationUserInfoService
    {
        Task<ApplicationUserInfo> GetApplicationUserInfoById(string id);

        Task<ApplicationUserInfo> GetApplicationUserInfoByJRId(int id);

        void InsertApplicationUserInfo(ApplicationUserInfo entity);

        void UpdateApplicationUserInfo(ApplicationUserInfo entity);

        void DeleteApplicationUserInfo(ApplicationUserInfo entity);
    }
}