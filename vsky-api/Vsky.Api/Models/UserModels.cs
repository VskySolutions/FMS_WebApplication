using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Vsky.Api.Framework.Models;
using Vsky.Models;

namespace Vsky.Api.Models
{
    public record UserModel : BaseEntityModel
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public DateTimeOffset? LockoutEnd { get; set; }

        public bool LockoutEnabled { get; set; }

        public int AccessFailedCount { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UpdatedById { get; set; }

        public DateTime? UpdatedOnUtc { get; set; }

        public string RoleId { get; set; }

        public string Password { get; set; }

        public bool Active { get; set; }

        public IFormFile File { get; set; }

        public string ProfilePictureId { get; set; }

        public string Filename { get; set; }

        public string ChangeFlag { get; set; }

        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }


    }
}