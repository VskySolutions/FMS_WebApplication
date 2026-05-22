using Microsoft.AspNetCore.Identity;

namespace Vsky.Models
{
    public class ApplicationUserToken : IdentityUserToken<string>
    {
        public virtual ApplicationUser User { get; set; }
    }
}