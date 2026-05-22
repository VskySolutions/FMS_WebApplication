using Microsoft.AspNetCore.Identity;

namespace Vsky.Models
{
    public class ApplicationUserLogin : IdentityUserLogin<string>
    {
        public virtual ApplicationUser User { get; set; }
    }
}