using AdvoSecure.Domain.Entities.Base;

namespace AdvoSecure.Domain.Entities
{
    public class Tenant : AuditableEntityIncrementalInt
    {
        public string Name { get; set; }
        public string SchemaName { get; set; }
        public string AzureTenantId { get; set; }
        public string ConnectionString { get; set; }
        public int? AdminTenantId { get; set; }
    }
}
