using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Vsky.Api.Framework.Models;
using Vsky.Models;

namespace Vsky.Api.Models
{
    public record DropDownModel : BaseEntityModel
    {
        public string DropDownTypeId { get; set; }

        public string DropDownValue { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public int Sortorder { get; set; }

        public string Type { get; set; }

        public string FilePath { get; set; }

        public bool Active { get; set; }

        public virtual DropDownModel DropDownType { get; set; }
        
        public record DropDownSearchModel : BaseSearchModel
        {
            public string DropDownTypeId { get; set; }
        }

        public record DropDownListModel : BasePagedListModel<DropDownModel> { }
    }

    public record DropDownViewModel : BaseEntityModel
    {
        public string DropDownTypeId { get; set; }

        public string DropdownValue { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public string FilePath { get; set; }

        public string MinAge { get; set; }

        public string MaxAge { get; set; }

        public int Sortorder { get; set; }
    }
}