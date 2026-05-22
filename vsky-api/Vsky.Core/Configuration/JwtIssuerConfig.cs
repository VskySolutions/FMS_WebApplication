using System;
using System.Threading.Tasks;

namespace Vsky.Core.Configuration
{
    public class JwtTokenConfig
    {
        public string Issuer { get; set; }

        public string Audience { get; set; }

        public DateTime NotBefore => DateTime.UtcNow;

        public DateTime IssuedAt => DateTime.UtcNow;

        public TimeSpan ValidFor { get; set; } = TimeSpan.FromMinutes(300);

        public DateTime Expiration => IssuedAt.Add(ValidFor);

        public Func<Task<string>> JtiGenerator => () => Task.FromResult(Guid.NewGuid().ToString());

        public string SecurityKey { get; set; }
    }
}