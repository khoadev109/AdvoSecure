using System.ComponentModel.DataAnnotations;

namespace AdvoSecure.Domain.Entities.Base
{
    public class BaseGuidEntity : AuditableEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
