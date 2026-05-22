using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Vsky.Core;

namespace Vsky.Models;

public class DropDown : BaseEntity
{
    public string DropDownTypeId { get; set; }

    public string DropDownValue { get; set; }

    public string DisplayName { get; set; }

    public int Sortorder { get; set; }

    public string Description { get; set; }

    public string Type { get; set; }

    public string FilePath { get; set; }

    public DateTime CreatedOnUtc { get; set; }

    public string CreatedById { get; set; }

    public DateTime? UpdatedOnUtc { get; set; }

    public string UpdatedById { get; set; }

    public bool Active { get; set; }

    public bool Deleted { get; set; }

    public virtual DropDown DropDownType { get; set; }

    [NotMapped]
    public string MinAge { get; set; }
    [NotMapped]
    public string MaxAge { get; set; }
    [NotMapped]
    public string orderbyColumn { get; set; }
}