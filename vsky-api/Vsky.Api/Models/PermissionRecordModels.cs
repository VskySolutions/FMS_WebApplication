using Vsky.Api.Framework.Models;

namespace Vsky.Api.Models
{
    public record PermissionRecordModel : BaseEntityModel
    {
        public string Name { get; set; }

        public string SystemName { get; set; }

        public string Category { get; set; }
    }
}