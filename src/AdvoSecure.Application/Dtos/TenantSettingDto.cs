namespace AdvoSecure.Application.Dtos
{
    public class TenantSettingDto : BaseDto
    {
        public string Name { get; set; }
        
        public string SchemaName { get; set; }

        public Guid TenantIdentifier { get; set; }
        
        public string ConnectionString { get; set; }
        
        public int? AdminId { get; set; }
        
        public TenantBillingDto Billing { get; set; }
    }

    public class TenantWithAdminDto : TenantSettingDto
    {
        public Guid TenantAdminIdentifier { get; set; }
    }
}
