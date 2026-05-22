using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vsky.Core;
using Vsky.Data;
using Vsky.Models;

namespace Vsky.Services.Menus
{
    public class MenuPermissionService : IMenuPermissionService
    {
        #region Fields
        private readonly IRepository<MenuPermission> _menuPermissionRepository;
        #endregion

        #region Ctor
        public MenuPermissionService(IRepository<MenuPermission> menuPermissionRepository)
        {
            _menuPermissionRepository = menuPermissionRepository;
        }
        #endregion

        #region Public Methods

        public async Task<MenuPermission> GetMenuPermissionById(string id)
        {
            var query = _menuPermissionRepository.Table.Where(x => !x.Deleted && x.Id == id);

            var item = await query.FirstOrDefaultAsync();

            return item;
        }

        public async Task<MenuPermission> GetMenuPermissionByMenuNameAndRole(string menuName, string roleId)
        {
            var query = _menuPermissionRepository.Table.Where(x => !x.Deleted && x.RoleId == roleId && x.Menu.MenuName == menuName);

            var item = await query.FirstOrDefaultAsync();

            return item;
        }

        public async Task<MenuPermission> GetMenuPermissionByMenuAndRole(string MenuId, string RoleId)
        {
            var query = _menuPermissionRepository.Table.Where(x => !x.Deleted && x.MenuId == MenuId && x.RoleId == RoleId);

            var item = await query.FirstOrDefaultAsync();

            return item;
        }

        public void InsertMenuPermission(MenuPermission entity)
        {
            _menuPermissionRepository.Insert(entity);
        }

        public void UpdateMenuPermission(MenuPermission entity)
        {
            _menuPermissionRepository.Update(entity);
        }

        public void DeleteMenuPermission(MenuPermission entity)
        {
            entity.Deleted = true;
            _menuPermissionRepository.Update(entity);
        }

        #endregion
    }
}