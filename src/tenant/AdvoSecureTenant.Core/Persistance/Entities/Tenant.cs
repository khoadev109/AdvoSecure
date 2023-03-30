namespace AdvoSecureTenant.Core.Persistance.Entities
{
    public class Tenant : BaseEntity
    {
        public string SchemaName { get; set; }
        public string Name { get; set; }
        public string AzureTenantId { get; set; }
        public string ConnectionString { get; set; }
        public int? AdminTenantId { get; set; } = null;
    }
}
