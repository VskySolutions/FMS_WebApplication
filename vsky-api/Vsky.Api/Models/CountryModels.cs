using Vsky.Api.Framework.Models;

namespace Vsky.Api.Models
{
    public record CountryModel : BaseEntityModel
    {
        public string Name { get; set; }

        public string TwoLetterIsoCode { get; set; }

        public string ThreeLetterIsoCode { get; set; }

        public int NumericIsoCode { get; set; }

        public bool Active { get; set; }

        public int DisplayOrder { get; set; }
    }
}