using System.Collections.Generic;
using Vsky.Core;

namespace Vsky.Models;

public class PermissionRecord : BaseEntity
{
    public string Name { get; set; }

    public string SystemName { get; set; }

    public string Category { get; set; }

    public virtual ICollection<ApplicationRole> Roles { get; set; } = new List<ApplicationRole>();
}