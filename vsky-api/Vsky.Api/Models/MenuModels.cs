using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Vsky.Api.Framework.Models;
using Vsky.Models;

namespace Vsky.Api.Models
{
    public record MenuModel : BaseEntityModel
    {
        public string ModuleId { get; set; }

        public string MenuName { get; set; }

        public string DisplayName { get; set; }

        public int Sortorder { get; set; }

        public string ParentMenuId { get; set; }

        public bool Active { get; set; }

        public string Icon { get; set; }

        public string Link { get; set; }

        public DateTime CreatedOnUtc { get; set; }

        public string CreatedById { get; set; }

        public string UpdatedById { get; set; }

        public DateTime? UpdatedOnUtc { get; set; }

        public bool Deleted { get; set; }

        public bool IsManageMenuPermission { get; set; }

        public bool IsViewMenuPermission { get; set; }

        public virtual ICollection<MenuPermissionModel> MenuPermissions { get; set; } = new List<MenuPermissionModel>();
    }

    public record MenuSearchModel : BaseSearchModel
    {
        public string Name { get; set; }
    }

    public record MenuListModel : BasePagedListModel<MenuModel> { }

}