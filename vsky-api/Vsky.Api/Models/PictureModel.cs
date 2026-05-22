using Vsky.Api.Framework.Models;

namespace Vsky.Api.Models
{
    public record PictureModel : BaseEntityModel
    {
        public string MimeType { get; set; }

        public string SeoFilename { get; set; }

        public string AltAttribute { get; set; }

        public string TitleAttribute { get; set; }

        public bool IsNew { get; set; }

        public string VirtualPath { get; set; }

        public string FileName { get; set; }
    }
}
