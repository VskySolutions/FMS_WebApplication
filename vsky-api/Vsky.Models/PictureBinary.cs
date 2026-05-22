using Vsky.Core;

namespace Vsky.Models
{
    public class PictureBinary : BaseEntity
    {
        public string PictureId { get; set; }

        public byte[] BinaryData { get; set; }

        public virtual Picture Picture { get; set; }
    }
}