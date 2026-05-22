using Microsoft.AspNetCore.Identity;

namespace Vsky.Models
{
    public class ApplicationUserClaim : IdentityUserClaim<string>
    {
        public virtual ApplicationUser User { get; set; }
    }
}