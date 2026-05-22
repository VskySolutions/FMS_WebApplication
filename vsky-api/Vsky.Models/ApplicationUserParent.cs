using System;
using Vsky.Core;

namespace Vsky.Models;

public class ApplicationUserParent : BaseEntity
{
    
    public string StudentId { get; set; }

    public string ParentId { get; set; }
    
}