namespace Vsky.Api.Framework.Models
{
    public partial record BaseEntityModel : BaseModel
    {
        public virtual string Id { get; set; }
    }
}