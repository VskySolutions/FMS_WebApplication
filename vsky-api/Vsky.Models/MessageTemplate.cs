using Vsky.Core;

namespace Vsky.Models;

public class MessageTemplate : BaseEntity
{
    public string Name { get; set; }

    public string BccEmailAddresses { get; set; }

    public string Subject { get; set; }

    public string EmailAccountId { get; set; }

    public string Body { get; set; }

    public bool Active { get; set; }

    public int? DelayBeforeSend { get; set; }

    public int? DelayPeriodId { get; set; }

    public string AttachedDownloadId { get; set; }
}