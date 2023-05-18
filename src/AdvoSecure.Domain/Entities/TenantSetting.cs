using AdvoSecure.Domain.Entities.Base;

namespace AdvoSecure.Domain.Entities
{
    public class TenantSetting : BaseEntity
    {
        public Guid TenantIdentifier { get; set; }

        public string Name { get; set; }
        
        public string SchemaName { get; set; }
        
        public string ConnectionString { get; set; }
        
        public int? AdminId { get; set; }

        public TenantBilling TenantBilling { get; set; }

        public IList<TenantDirectory> TenantDirectories { get; set; } = new List<TenantDirectory>();
    }
}
