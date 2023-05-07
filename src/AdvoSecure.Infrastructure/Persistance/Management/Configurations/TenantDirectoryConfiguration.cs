using AdvoSecure.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdvoSecure.Infrastructure.Persistance.Management.Configurations
{
    public class TenantDirectoryConfiguration : IEntityTypeConfiguration<TenantDirectory>
    {
        public void Configure(EntityTypeBuilder<TenantDirectory> builder)
        {
            builder.ToTable("TenantDirectories")
                    .HasKey(td => new { td.TenantId, td.UserId });

            builder.HasOne<TenantSetting>(td => td.Tenant)
                    .WithMany(t => t.TenantDirectories)
                    .HasForeignKey(t => t.TenantId);


            builder.HasOne<TenantUser>(td => td.User)
                    .WithMany(u => u.TenantDirectories)
                    .HasForeignKey(t => t.UserId);
        }
    }
}
