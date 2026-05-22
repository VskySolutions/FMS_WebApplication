using System.Collections.Generic;
using Vsky.Api.Framework.Models;

namespace Vsky.Api.Models
{
    public record ActivityLogTypeModel : BaseEntityModel
    {
        public string SystemKeyword { get; set; }

        public string Name { get; set; }

        public bool Enabled { get; set; }

        public virtual ICollection<ActivityLogModel> ActivityLogs { get; set; } = new List<ActivityLogModel>();
    }
}