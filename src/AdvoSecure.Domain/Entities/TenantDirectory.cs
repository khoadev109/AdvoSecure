using AdvoSecure.Domain.Entities.Base;

namespace AdvoSecure.Domain.Entities
{
    public class TenantDirectory : BaseEntity
    {
        public int UserId { get; set; }
        public TenantUser User { get; set; }

        public int TenantId { get; set; }
        public TenantSetting Tenant { get; set; }
    }
}
