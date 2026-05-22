using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vsky.Api.ApiErrors;
using Vsky.Api.Extensions;
using Vsky.Api.Models;
using Vsky.Data;
using Vsky.Models;
using Vsky.Services.Menus;
using static Vsky.Api.Models.MenuModel;

namespace Vsky.Api.Controllers
{
    [Route("menus")]
    public class MenusController : BaseController
    {
        #region Fields
        private readonly IMapper _mapper;
        private readonly IMenuService _menuService;
        private readonly IMenuPermissionService _menuPermissionService;
        private readonly ApplicationDbContext _db;
        #endregion

        #region Ctor
        public MenusController(IMapper mapper, IMenuService menuService, IMenuPermissionService menuPermissionService, ApplicationDbContext db)
        {
            _mapper = mapper;
            _menuService = menuService;
            _menuPermissionService = menuPermissionService;
            _db = db;
        }
        #endregion

        #region Menu Methods 

        [HttpGet]
        public async Task<IActionResult> GetAllMenus(string roleId=null)
        {
            var list = await _menuService.GetAllMenus(roleId);

            var model = _mapper.Map<IList<MenuModel>>(list);

            return Ok(model);
        }

        [HttpGet("modulemenus")]
        public async Task<IActionResult> GetAllModuleMenus(string moduleId = null)
        {
            var list = await _menuService.GetAllModuleMenus(moduleId);

            var model = _mapper.Map<IList<MenuModel>>(list);

            return Ok(model);
        }

        [HttpGet("parent")]
        public async Task<IActionResult> GetAllParentMenus()
        {
            var list = await _menuService.GetAllParentMenus();

            var model = _mapper.Map<IList<MenuModel>>(list);

            return Ok(model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMenuById(string id)
        {
            var entity = await _menuService.GetMenuById(id);

            if (entity == null)
            {
                return BadRequest(new BadRequestError("No Menu found with the specified id."));
            }

            var model = _mapper.Map<MenuModel>(entity);

            return Ok(model);
        }

        [HttpPost]
        public IActionResult CreateMenu(MenuModel model)
        {
            if (ModelState.IsValid)
            {
                var exists = _db.Menus.Any(x => x.DisplayName == model.DisplayName && x.ModuleId==model.ModuleId && !x.Deleted);

                if (exists)
                {
                    return BadRequest(new BadRequestError("Menu name already exists."));
                }
                var entity = _mapper.Map<Menu>(model);
                entity.ParentMenuId = model.ParentMenuId!="" ? model.ParentMenuId : null;
                entity.CreatedById = User.GetLoggedInUserId<string>();
                entity.CreatedOnUtc = DateTime.UtcNow;

                _menuService.InsertMenu(entity);

                return NoContent();
            }

            return ModelStateError(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMenu(string id, MenuModel model)
        {
            if (ModelState.IsValid)
            {
                var exists = _db.Menus.Any(x => x.DisplayName == model.DisplayName && !x.Deleted && x.Id != id);
                if (exists)
                {
                    return BadRequest(new BadRequestError("Menu name already exists."));
                }

                var entity = await _menuService.GetMenuById(id);

                if (entity == null)
                {
                    return BadRequest(new BadRequestError("No menu found with the specified id."));
                }

                entity = _mapper.Map(model, entity);

                entity.ParentMenuId = model.ParentMenuId != "" ? model.ParentMenuId : null;
                entity.UpdatedById = User.GetLoggedInUserId<string>();
                entity.UpdatedOnUtc = DateTime.UtcNow;

                _menuService.UpdateMenu(entity);

                return NoContent();
            }

            return ModelStateError(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenu(string id)
        {
            var entity = await _menuService.GetMenuById(id);

            if (entity == null)
            {
                return BadRequest(new BadRequestError("No menu found with the specified id."));
            }

            _menuService.DeleteMenu(entity);

            return NoContent();
        }

        #endregion

        #region Menu Permissions Methods 

        [HttpPost("savepermission")]
        public async Task<IActionResult> CreateMenuPermission(MenuPermissionModel model)
        {
            if (ModelState.IsValid)
            {
                
                var exists = _db.MenuPermissions.Any(x => x.MenuId == model.MenuId && x.RoleId == model.RoleId && !x.Deleted);

                if (exists) //Update permission
                {
                    var Permission = _menuPermissionService.GetMenuPermissionByMenuAndRole(model.MenuId, model.RoleId);

                    var entity = await _menuPermissionService.GetMenuPermissionById(Permission.Result.Id);
                    if (entity == null)
                        return BadRequest(new BadRequestError("No menu found with the specified id."));
                  
                    entity.IsView = model.PermissionType == "V" ? model.PermissionStatus : Permission.Result.IsView;
                    entity.IsManage = model.PermissionType == "M" ? model.PermissionStatus : Permission.Result.IsManage;
                    entity.UpdatedById = User.GetLoggedInUserId<string>();
                    entity.UpdatedOnUtc = DateTime.UtcNow;
                    _menuPermissionService.UpdateMenuPermission(entity);
                }
                else //Create permission
                {
                    var entity = _mapper.Map<MenuPermission>(model);
                    entity = _mapper.Map(model, entity);
                    entity.IsView = model.PermissionType=="V" ? true : false;
                    entity.IsManage = model.PermissionType == "M" ? true : false;
                    entity.CreatedById = User.GetLoggedInUserId<string>();
                    entity.CreatedOnUtc = DateTime.UtcNow;
                    _menuPermissionService.InsertMenuPermission(entity);
                }

                return NoContent();
            }

            return ModelStateError(ModelState);
        }

        #endregion
    }
}
