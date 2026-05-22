using Microsoft.AspNetCore.Mvc;

namespace Vsky.Api.Framework.Models
{
    public abstract partial record BaseSearchModel : BaseModel, IPagingRequestModel
    {
        #region Ctor

        protected BaseSearchModel()
        {
            Page = 1;
            PageSize = 100;
        }

        #endregion

        #region Properties

        [FromQuery(Name = "filter")]
        public string Filter { get; set; }

        [FromQuery(Name = "page")]
        public int Page { get; set; } = 1;

        [FromQuery(Name = "pageSize")]
        public int PageSize { get; set; } = int.MaxValue;

        [FromQuery(Name = "sortBy")]
        public string SortBy { get; set; }

        [FromQuery(Name = "descending")]
        public bool Descending { get; set; }

        #endregion
    }
}