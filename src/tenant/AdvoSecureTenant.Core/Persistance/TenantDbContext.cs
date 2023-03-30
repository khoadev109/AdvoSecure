using AdvoSecureTenant.Core.Persistance.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AdvoSecureTenant.Core.Persistance
{
    public class TenantDbContext : DbContext
    {
        public TenantDbContext(DbContextOptions<TenantDbContext> options) : base(options)
        {
        }

        public DbSet<Tenant> Tenants => Set<Tenant>();
        public DbSet<TenantBase> TenantBases => Set<TenantBase>();
        public DbSet<TenantBilling> TenantBillings => Set<TenantBilling>();
        public DbSet<TenantMapping> TenantMappings => Set<TenantMapping>();
        public DbSet<Zone> Zones => Set<Zone>();
        public DbSet<TenantSetting> TenantSettings => Set<TenantSetting>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
