using Vsky.Api.Framework.Models;

namespace Vsky.Api.Models
{
    public record StateProvinceModel : BaseEntityModel
    {
        public string Name { get; set; }

        public string Abbreviation { get; set; }

        public string CountryId { get; set; }

        public bool Active { get; set; }

        public int DisplayOrder { get; set; }
    }
}