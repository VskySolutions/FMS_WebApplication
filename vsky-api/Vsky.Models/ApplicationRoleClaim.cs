using Microsoft.AspNetCore.Identity;

namespace Vsky.Models
{
    public class ApplicationRoleClaim : IdentityRoleClaim<string>
    {
        public virtual ApplicationRole Role { get; set; }
    }
}