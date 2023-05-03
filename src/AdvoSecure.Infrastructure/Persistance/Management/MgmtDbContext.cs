using AdvoSecure.Domain.Entities;
using AdvoSecure.Domain.Entities.Base;
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
