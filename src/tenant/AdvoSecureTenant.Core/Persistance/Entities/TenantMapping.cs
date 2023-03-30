namespace AdvoSecureTenant.Core.Persistance.Entities
{
    public class TenantMapping : BaseEntity
    {
        public int BaseId { get; set; }
        public int TenantId { get; set; }
        public int ZoneId { get; set; }
    }
}
