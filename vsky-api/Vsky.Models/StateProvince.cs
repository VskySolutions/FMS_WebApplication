using Vsky.Core;

namespace Vsky.Models;

public class StateProvince : BaseEntity
{
    public string Name { get; set; }

    public string Abbreviation { get; set; }

    public string CountryId { get; set; }

    public bool Active { get; set; }

    public int DisplayOrder { get; set; }

    public virtual Country Country { get; set; }
}