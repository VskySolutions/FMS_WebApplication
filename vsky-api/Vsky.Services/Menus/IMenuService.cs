using System.Collections.Generic;
using System.Threading.Tasks;
using Vsky.Core;
using Vsky.Models;

namespace Vsky.Services.Menus
{
    public interface IMenuService
    {
        Task<IList<Menu>> GetAllMenus(string roleId);

        Task<IList<Menu>> GetAllModuleMenus(string moduleId);

        Task<IList<Menu>> GetAllParentMenus();

        Task<Menu> GetMenuById(string id);

        Task<Menu> GetMenuByName(string name);

        void InsertMenu(Menu entity);

        void UpdateMenu(Menu entity);

        void DeleteMenu(Menu entity);
    }
}