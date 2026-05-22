using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Vsky.Core;

namespace Vsky.Models;

public class MenuPermission : BaseEntity
{
    public string MenuId { get; set; }

    public string RoleId { get; set; }

    public bool IsManage { get; set; }

    public bool IsView { get; set; }

    public DateTime CreatedOnUtc { get; set; }

    public string CreatedById { get; set; }

    public string UpdatedById { get; set; }

    public DateTime? UpdatedOnUtc { get; set; }

    public bool Deleted { get; set; }

    [NotMapped]
    public virtual Menu Menu { get; set; }
}