using System.Collections.Generic;
using Vsky.Core;

namespace Vsky.Models;

public class Country : BaseEntity
{
    public string Name { get; set; }

    public string TwoLetterIsoCode { get; set; }

    public string ThreeLetterIsoCode { get; set; }

    public int NumericIsoCode { get; set; }

    public bool Active { get; set; }

    public int DisplayOrder { get; set; }

    public virtual ICollection<StateProvince> StateProvinces { get; set; } = new List<StateProvince>();
}