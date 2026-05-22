using System.ComponentModel.DataAnnotations.Schema;

namespace Vsky.Core
{
    public abstract class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
    }
}