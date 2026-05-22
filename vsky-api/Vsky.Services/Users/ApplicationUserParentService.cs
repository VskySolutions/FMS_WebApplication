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
    public class ApplicationUserParentService : IApplicationUserParentService
    {
        #region Fields
        private readonly IRepository<ApplicationUserParent> _applicationUserParentRepository;
        #endregion

        #region Ctor
        public ApplicationUserParentService(IRepository<ApplicationUserParent> applicationUserParentRepository)
        {
            _applicationUserParentRepository = applicationUserParentRepository;
        }
        #endregion

        #region Private Methods
        #endregion

        #region Public Methods

        #region Insert Application User Parent
        public void InsertApplicationUserParent(ApplicationUserParent entity)
        {
            _applicationUserParentRepository.Insert(entity);
        }
        #endregion

        #region Update Application User Parent
        public void UpdateApplicationUserParent(ApplicationUserParent entity)
        {
            _applicationUserParentRepository.Update(entity);
        }
        #endregion       

        #endregion
    }
}