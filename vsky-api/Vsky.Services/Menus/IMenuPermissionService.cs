using System.Threading.Tasks;
using Vsky.Core;
using Vsky.Models;

namespace Vsky.Services.Menus
{
    public interface IMenuPermissionService
    {
        Task<MenuPermission> GetMenuPermissionById(string id);

        Task<MenuPermission> GetMenuPermissionByMenuNameAndRole(string Menu, string RoleId);

        Task<MenuPermission> GetMenuPermissionByMenuAndRole(string MenuId, string RoleId);

        void InsertMenuPermission(MenuPermission entity);

        void UpdateMenuPermission(MenuPermission entity);

        void DeleteMenuPermission(MenuPermission entity);
    }
}