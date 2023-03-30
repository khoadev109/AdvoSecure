namespace AdvoSecureTenant.Core.Services.Dtos
{
    public class TenantDto
    {
        public int Id { get; set; }
        public string SchemaName { get; set; }
        public string Name { get; set; }
        public string AzureTenantId { get; set; }
        public string ConnectionString { get; set; } = string.Empty;
        public int? AdminTenantId { get; set; } = null;
    }
}
