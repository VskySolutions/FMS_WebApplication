using System;
using Vsky.Core;

namespace Vsky.Models;

public class ActivityLog : BaseEntity
{
    public string Comment { get; set; }

    public string IpAddress { get; set; }

    public string EntityName { get; set; }

    public string ActivityLogTypeId { get; set; }

    public string UserId { get; set; }

    public string EntityId { get; set; }

    public DateTime CreatedOnUtc { get; set; }

    public virtual ActivityLogType ActivityLogType { get; set; }

    public virtual ApplicationUser User { get; set; }
}