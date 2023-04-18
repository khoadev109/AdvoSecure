using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvoSecure.Domain.Entities.Base;

public interface IAuditableEntity<TKey>
{
    [Key]
    public TKey Id { get; set; }

    public string CreatedBy { get; set; }
    
    public DateTime CreatedDateTime { get; set; }

    public string ModifiedBy { get; set; }

    public DateTime? ModifiedDateTime { get; set; }

    public string DeletedBy { get; set; }

    public DateTime? DeletedDateTime { get; set; }
}

public class AuditableEntity<TKey> : IAuditableEntity<TKey>
{
    public TKey Id { get; set; }

    public string CreatedBy { get; set; }
    
    public DateTime CreatedDateTime { get; set; } = DateTime.Now;

    public string ModifiedBy { get; set; } = string.Empty;
    
    public DateTime? ModifiedDateTime { get; set; } = null;

    public string DeletedBy { get; set; } = string.Empty;
    
    public DateTime? DeletedDateTime { get; set; } = null;
}

public class BaseAuditableEntity<TKey> : AuditableEntity<TKey>
{
    public int CreatedById { get; set; }
}

public class AuditableEntity : AuditableEntity<Guid>
{
}

public class AuditableEntityIncrementalInt : AuditableEntity<int>
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public new int Id { get; set; }
}

public class BaseEntity : BaseAuditableEntity<int>
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public new int Id { get; set; }
}
