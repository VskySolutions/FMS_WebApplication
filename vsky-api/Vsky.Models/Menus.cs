using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Vsky.Core;

namespace Vsky.Models;

public class Menu : BaseEntity
{
    public string ModuleId { get; set; }

    public string MenuName { get; set; }

    public string DisplayName { get; set; }

    public int Sortorder { get; set; }

    public string ParentMenuId { get; set; }

    public bool Active { get; set; }

    public string Link { get; set; }

    public string Icon { get; set; }

    public DateTime CreatedOnUtc { get; set; }

    public string CreatedById { get; set; }

    public string UpdatedById { get; set; }

    public DateTime? UpdatedOnUtc { get; set; }

    public bool Deleted { get; set; }

    [NotMapped]
    public bool IsManageMenuPermission { get; set; }

    [NotMapped]
    public bool IsViewMenuPermission { get; set; }

    public virtual ICollection<MenuPermission> MenuPermissions { get; set; } = new List<MenuPermission>();
}