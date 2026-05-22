using Vsky.Core;

namespace Vsky.Models;

public class Setting : BaseEntity
{
    public Setting(string name, string value, string referenceId)
    {
        Name = name;
        Value = value;
        ReferenceId = referenceId;
    }

    public string Name { get; set; }

    public string Value { get; set; }

    public string ReferenceId { get; set; }

    public override string ToString()
    {
        return Name;
    }
}