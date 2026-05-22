using System;
using System.Collections.Generic;
using Vsky.Api.Framework.Models;
using Vsky.Models;

namespace Vsky.Api.Models
{
    public record ApplicationUserParentModel : BaseEntityModel
    {
        public string StudentId { get; set; }

        public string ParentId { get; set; }
      
    }  

}