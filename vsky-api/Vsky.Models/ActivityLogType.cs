using System.Collections.Generic;
using Vsky.Core;

namespace Vsky.Models;

public class ActivityLogType : BaseEntity
{
    public string SystemKeyword { get; set; }

    public string Name { get; set; }

    public bool Enabled { get; set; }

    public virtual ICollection<ActivityLog> ActivityLogs { get; set; } = new List<ActivityLog>();
}