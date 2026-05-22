using System;
using System.Collections.Generic;
using Vsky.Api.Framework.Models;

namespace Vsky.Api.Models
{
    public record RoleModel : BaseEntityModel
    {
        public string Name { get; set; }

        public string NormalizedName { get; set; }

        public string ConcurrencyStamp { get; set; }

        public bool IsPrimaryRole { get; set; }

        public IList<RoleModel> Data { get; internal set; }
        public int Total { get; internal set; }
    }
}