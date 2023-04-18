using AdvoSecure.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AdvoSecure.Infrastructure.Persistance.Tenant
{
    public class MgmtDbContext : DbContext
    {
        public MgmtDbContext(DbContextOptions<MgmtDbContext> options) : base(options)
        {
        }

        public DbSet<TenantSetting> TenantSettings => Set<TenantSetting>();
        public DbSet<TenantBilling> TenantBillings => Set<TenantBilling>();
        public DbSet<TenantDirectory> TenantDirectories => Set<TenantDirectory>();
        public DbSet<TenantUser> TenantUsers => Set<TenantUser>();
        public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Entities.TenantSetting>()
                .HasOne(x => x.TenantBilling)
                .WithOne(y => y.TenantSetting)
                .HasForeignKey<TenantBilling>(y => y.TenantId);

            modelBuilder.Entity<TenantDirectory>().ToTable("TenantDirectories").HasKey(td => new { td.TenantId, td.UserId });

            modelBuilder.Entity<TenantDirectory>()
                    .HasOne<TenantSetting>(td => td.Tenant)
                    .WithMany(t => t.TenantDirectories)
                    .HasForeignKey(t => t.TenantId);


            modelBuilder.Entity<TenantDirectory>()
                    .HasOne<TenantUser>(td => td.User)
                    .WithMany(u => u.TenantDirectories)
                    .HasForeignKey(t => t.UserId);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
