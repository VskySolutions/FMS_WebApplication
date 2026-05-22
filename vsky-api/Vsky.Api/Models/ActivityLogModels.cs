using Vsky.Api.Framework.Models;

namespace Vsky.Api.Models
{
    public record ActivityLogModel : BaseEntityModel
    {
        public string Comment { get; set; }

        public string IpAddress { get; set; }

        public string EntityName { get; set; }

        public string ActivityLogTypeId { get; set; }

        public string UserId { get; set; }

        public string EntityId { get; set; }

        public virtual ActivityLogTypeModel ActivityLogType { get; set; }

        public virtual UserModel User { get; set; }
    }
}