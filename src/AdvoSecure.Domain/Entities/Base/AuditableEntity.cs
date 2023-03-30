using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvoSecure.Domain.Entities.Base;

public interface IAuditableEntity<TKey>
{
    [Key]
    TKey Id { get; set; }
    string CreatedBy { get; set; }
    DateTime CreatedDateTime { get; set; }
    string ModifiedBy { get; set; }
    DateTime? ModifiedDateTime { get; set; }
    string DeletedBy { get; set; }
    DateTime? DeletedDateTime { get; set; }
}

public class AuditableEntity<TKey> : IAuditableEntity<TKey>
{
    public TKey Id { get; set; }

    public string CreatedBy { get; set; }
    public DateTime CreatedDateTime { get; set; }

    public string ModifiedBy { get; set; } = string.Empty;
    public DateTime? ModifiedDateTime { get; set; } = null;

    public string DeletedBy { get; set; } = string.Empty;
    public DateTime? DeletedDateTime { get; set; } = null;
}

public class AuditableEntity : AuditableEntity<Guid>
{
}

public class AuditableEntityIncrementalInt : AuditableEntity<int>
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public new int Id { get; set; }
}
