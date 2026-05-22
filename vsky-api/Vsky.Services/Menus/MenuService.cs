using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vsky.Core;
using Vsky.Data;
using Vsky.Models;
    
namespace Vsky.Services.Menus
{
    public class MenuService : IMenuService
    {
        #region Fields
        private readonly IRepository<Menu> _menuRepository;
        #endregion

        #region Ctor
        public MenuService(IRepository<Menu> menuRepository)
        {
            _menuRepository = menuRepository;
        }
        #endregion

        #region Private Methods
        private static string GetOrderBy(string orderBy)
        {
            return orderBy;
        }
        #endregion

        #region Public Methods
        public async Task<IList<Menu>> GetAllMenus(string roleId)
        {
            var query = _menuRepository.Table;

            query = query.Where(x => !x.Deleted);

            query = query.OrderBy(x => x.Sortorder);

            query = query.Select(x => new Menu
            {
                Id = x.Id,
                MenuName = x.MenuName,
                DisplayName = x.DisplayName,
                Link = x.Link,
                Icon = x.Icon,
                Sortorder = x.Sortorder,
                Active = x.Active,
                ModuleId = x.ModuleId,
                MenuPermissions = (ICollection<MenuPermission>)x.MenuPermissions.Where(m => m.RoleId== roleId),
            });

            var list = await query.ToListAsync();

            return list;
        }

        public async Task<IList<Menu>> GetAllModuleMenus(string ModuleId)
        {
            var query = _menuRepository.Table;

            query = query.Where(x => !x.Deleted && x.ModuleId == ModuleId);

            query = query.OrderBy(x => x.Sortorder);

            query = query.Select(x => new Menu
            {
                Id = x.Id,
                MenuName = x.MenuName,
                DisplayName = x.DisplayName,
                Link = x.Link,
                Icon = x.Icon,
                Sortorder = x.Sortorder,
                Active = x.Active,
                ModuleId = x.ModuleId
            });

            var list = await query.ToListAsync();

            return list;
        }

        public async Task<IList<Menu>> GetAllParentMenus()
        {
            var query = _menuRepository.Table.Where(x => !x.Deleted && x.ParentMenuId == null);

            query = query.OrderBy(x => x.Sortorder);

            query = query.Select(x => new Menu
            {
                Id = x.Id,
                MenuName = x.MenuName,
                DisplayName = x.DisplayName,
                Link = x.Link,
                Icon = x.Icon,
                Sortorder = x.Sortorder,
                Active = x.Active,
                ModuleId = x.ModuleId
            });

            var list = await query.ToListAsync();

            return list;
        }

        public async Task<Menu> GetMenuById(string id)
        {
            var query = _menuRepository.Table.Where(x => !x.Deleted && x.Id == id);

            var item = await query.FirstOrDefaultAsync();

            return item;
        }

        public async Task<Menu> GetMenuByName(string name)
        {
            var query = _menuRepository.Table.Where(x => !x.Deleted && x.MenuName == name);

            var item = await query.FirstOrDefaultAsync();

            return item;
        }

        public void InsertMenu(Menu entity)
        {
            _menuRepository.Insert(entity);
        }

        public void UpdateMenu(Menu entity)
        {
            _menuRepository.Update(entity);
        }

        public void DeleteMenu(Menu entity)
        {
            entity.Deleted = true;
            _menuRepository.Update(entity);
        }

        #endregion
    }
}