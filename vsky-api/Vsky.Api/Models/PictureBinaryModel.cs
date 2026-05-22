using Vsky.Api.Framework.Models;

namespace Vsky.Api.Models
{
    public record PictureBinaryModel : BaseEntityModel
    {
        public byte[] BinaryData { get; set; }
    }
}
