using System;
using System.ComponentModel.DataAnnotations.Schema;
using Vsky.Core;

namespace Vsky.Models;

public class ApplicationUserInfo : BaseEntity
{
    
    public string UserId { get; set; }

    public int JackrabbitUserId { get; set; }

    public string Type { get; set; }

    public string Address1 { get; set; }

    public string Address2 { get; set; }

    public string State { get; set; }

    public string FamilyLastName { get; set; }

    public string HomeAddress { get; set; }

    public string City { get; set; }

    public string ZipCode { get; set; }

    public string Gender { get; set; }

    public string BirthDate { get; set; }

    public string Location { get; set; }

    public string HomePhone { get; set; }

    public string WorkPhone { get; set; }

    public string CellPhone { get; set; }

    public bool IsBilling { get; set; }

    public bool IsPrimary { get; set; }

    public string CreatedById { get; set; }

    public DateTime CreatedOnUtc { get; set; }

    public string UpdatedById { get; set; }

    public DateTime? UpdatedOnUtc { get; set; }    

    public bool Deleted { get; set; }

    [NotMapped]
    public virtual ApplicationUser ApplicationUser { get; set; }
}