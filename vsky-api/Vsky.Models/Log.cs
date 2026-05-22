using System;
using Vsky.Core;

namespace Vsky.Models;

public class Log : BaseEntity
{
    public string ShortMessage { get; set; }

    public string IpAddress { get; set; }

    public string UserId { get; set; }

    public int LogLevelId { get; set; }

    public string FullMessage { get; set; }

    public string PageUrl { get; set; }

    public string ReferrerUrl { get; set; }

    public DateTime CreatedOnUtc { get; set; }

    public LogLevel LogLevel
    {
        get => (LogLevel)LogLevelId;
        set => LogLevelId = (int)value;
    }

    public virtual ApplicationUser User { get; set; }
}