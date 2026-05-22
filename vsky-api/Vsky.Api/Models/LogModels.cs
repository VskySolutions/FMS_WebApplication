using Vsky.Api.Framework.Models;

namespace Vsky.Api.Models
{
    public record LogModel : BaseEntityModel
    {
        public string ShortMessage { get; set; }
    }
}