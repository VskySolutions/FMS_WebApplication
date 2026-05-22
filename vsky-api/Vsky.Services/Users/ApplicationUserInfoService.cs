using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vsky.Core;
using Vsky.Data;
using Vsky.Models;

namespace Vsky.Services.Users
{
    public class ApplicationUserInfoService : IApplicationUserInfoService
    {
        #region Fields
        private readonly IRepository<ApplicationUserInfo> _applicationUserInfoRepository;
        #endregion

        #region Ctor
        public ApplicationUserInfoService(IRepository<ApplicationUserInfo> applicationUserInfoRepository)
        {
            _applicationUserInfoRepository = applicationUserInfoRepository;
        }
        #endregion

        #region Private Methods
        #endregion

        #region Public Methods

        #region Find Application User Info By Id
        public async Task<ApplicationUserInfo> GetApplicationUserInfoById(string id)
        {
            var query = _applicationUserInfoRepository.Table;

            query = query.Where(x => x.Id == id);

            query = query.Where(x => !x.Deleted);

            var item = await query.FirstOrDefaultAsync();

            return item;
        }
        #endregion

        #region Find Application User Info By Jack rabbit Id
        public async Task<ApplicationUserInfo> GetApplicationUserInfoByJRId(int id)
        {
            var query = _applicationUserInfoRepository.Table;

            query = query.Where(x => x.JackrabbitUserId == id);

            query = query.Where(x => !x.Deleted);

            var item = await query.FirstOrDefaultAsync();

            return item;
        }
        #endregion

        #region Insert Application User Info
        public void InsertApplicationUserInfo(ApplicationUserInfo entity)
        {
            _applicationUserInfoRepository.Insert(entity);
        }
        #endregion

        #region Update Application User Info
        public void UpdateApplicationUserInfo(ApplicationUserInfo entity)
        {
            _applicationUserInfoRepository.Update(entity);
        }
        #endregion

        #region Application User Info
        public void DeleteApplicationUserInfo(ApplicationUserInfo entity)
        {
            entity.Deleted = true;

            _applicationUserInfoRepository.Update(entity);
        }
        #endregion

        #endregion
    }
}