using System.ComponentModel.DataAnnotations;

namespace AdvoSecure.Domain.Entities.Base
{
    public class BaseStringEntity : AuditableEntity
    {
        [Key]
        public string Id { get; set; }
    }
}
