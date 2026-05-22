using System.Collections.Generic;
using System.Threading.Tasks;
using Vsky.Core;
using Vsky.Models;

namespace Vsky.Services.Users
{
    public interface IApplicationUserParentService
    {
        void InsertApplicationUserParent(ApplicationUserParent entity);

        void UpdateApplicationUserParent(ApplicationUserParent entity);
        
    }
}