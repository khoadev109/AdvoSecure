namespace AdvoSecureTenant.Core.Persistance.Entities
{
    public class TenantSetting : BaseEntity
    {
        public int AdminTenantId { get; set; }
        public List<string> AvailableTenants { get; set; } = new List<string>();
    }
}
