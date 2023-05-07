using AdvoSecure.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdvoSecure.Infrastructure.Persistance.Management.Configurations
{
    public class TenantSettingConfiguration : IEntityTypeConfiguration<TenantSetting>
    {
        public void Configure(EntityTypeBuilder<TenantSetting> builder)
        {
            builder
                .HasOne(x => x.TenantBilling)
                .WithOne(y => y.TenantSetting)
                .HasForeignKey<TenantBilling>(y => y.TenantId);
        }
    }
}
