using AdvoSecure.Domain.Entities;
using AdvoSecure.Domain.Entities.Base;
using AdvoSecure.Infrastructure.Persistance.Application.Configurations;
using AdvoSecure.Infrastructure.Persistance.Management.Configurations;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AdvoSecure.Infrastructure.Persistance.Management
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
            modelBuilder.ApplyConfiguration(new TenantDirectoryConfiguration());
            modelBuilder.ApplyConfiguration(new TenantSettingConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var insertedEntries = this.ChangeTracker.Entries()
                               .Where(x => x.State == EntityState.Added)
                               .Select(x => x.Entity);

            foreach (var insertedEntry in insertedEntries)
            {
                if (insertedEntry is IAuditableEntity auditableEntity)
                {
                    auditableEntity.CreatedDateTime = DateTime.Now;
                }
            }

            var modifiedEntries = this.ChangeTracker.Entries()
                       .Where(x => x.State == EntityState.Modified)
                       .Select(x => x.Entity);

            foreach (var modifiedEntry in modifiedEntries)
            {
                if (modifiedEntry is IAuditableEntity auditableEntity)
                {
                    auditableEntity.ModifiedDateTime = DateTime.Now;
                }
            }

            var deletedEntries = this.ChangeTracker.Entries()
                       .Where(x => x.State == EntityState.Deleted)
                       .Select(x => x.Entity);

            foreach (var deletedEntry in deletedEntries)
            {
                if (deletedEntry is IAuditableEntity auditableEntity)
                {
                    auditableEntity.DeletedDateTime = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
