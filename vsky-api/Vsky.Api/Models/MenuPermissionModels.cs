using System;
using System.Collections.Generic;
using Vsky.Api.Framework.Models;

namespace Vsky.Api.Models
{
    public record MenuPermissionModel : BaseEntityModel
    {
        public string MenuId { get; set; }

        public string RoleId { get; set; }

        public string PermissionType { get; set; }

        public bool PermissionStatus { get; set; }

        public bool IsManage { get; set; }

        public bool IsView { get; set; }

        public DateTime CreatedOnUtc { get; set; }

        public string CreatedById { get; set; }

        public string UpdatedById { get; set; }

        public DateTime? UpdatedOnUtc { get; set; }

        public bool Deleted { get; set; }

    }
}