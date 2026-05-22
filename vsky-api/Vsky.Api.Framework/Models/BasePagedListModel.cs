using System.Collections.Generic;

namespace Vsky.Api.Framework.Models
{
    public abstract partial record BasePagedListModel<T> : BaseModel, IPagedModel<T> where T : BaseModel
    {
        public IEnumerable<T> Data { get; set; }

        public int Total { get; set; }

        public object ExtraData { get; set; }

        public object Errors { get; set; }
    }
}