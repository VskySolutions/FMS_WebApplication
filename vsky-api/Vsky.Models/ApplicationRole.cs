using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Vsky.Models
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }

        public ApplicationRole(string name) : base(name) { }

        public bool IsPrimaryRole { get; set; }

        public string CreatedById { get; set; }

        public DateTime CreatedOnUtc { get; set; }

        public string UpdatedById { get; set; }

        public DateTime? UpdatedOnUtc { get; set; }

        //public bool Active { get; set; }

        public bool Deleted { get; set; }

        //public virtual Company Company { get; set; }

        public ICollection<ApplicationUserRole> UserRoles { get; set; }

        public virtual ICollection<ApplicationRoleClaim> RoleClaims { get; set; }

        public virtual ICollection<PermissionRecord> PermissionRecords { get; set; }
    }
}