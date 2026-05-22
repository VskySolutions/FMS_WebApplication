using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Vsky.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string CreatedById { get; set; }

        public DateTime? CreatedOnUtc { get; set; }

        public string UpdatedById { get; set; }

        public DateTime? UpdatedOnUtc { get; set; }

        public bool Active { get; set; }

        public bool Deleted { get; set; }

        public string ProfilePictureId { get; set; }

        public virtual Picture ProfilePicture { get; set; }

        public virtual ICollection<ApplicationUserClaim> Claims { get; set; }

        public virtual ICollection<ApplicationUserLogin> Logins { get; set; }

        public virtual ICollection<ApplicationUserToken> Tokens { get; set; }

        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }

        public virtual ICollection<ActivityLog> ActivityLogs { get; set; }



        

    }
}