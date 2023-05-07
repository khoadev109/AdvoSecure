using AdvoSecure.Domain.Entities;
using AdvoSecure.Domain.Entities.Base;
using AdvoSecure.Domain.Entities.Billings;
using AdvoSecure.Domain.Entities.Contacts;
using AdvoSecure.Domain.Entities.Matters;
using AdvoSecure.Domain.Entities.Notes;
using AdvoSecure.Domain.Entities.Tasks;
using AdvoSecure.Security;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AdvoSecure.Infrastructure.Persistance.App
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<BillingRate> BillingRates => Set<BillingRate>();

        public DbSet<BillingGroup> BillingGroups => Set<BillingGroup>();

        public DbSet<Country> Countries => Set<Country>();

        public DbSet<Contact> Contacts => Set<Contact>();

        public DbSet<Language> Languages => Set<Language>();

        public DbSet<CompanyLegalStatus> CompanyLegalStatuses => Set<CompanyLegalStatus>();

        public DbSet<ContactCivilStatus> ContactCivilStatuses => Set<ContactCivilStatus>();

        public DbSet<ContactIdType> ContactIdTypes => Set<ContactIdType>();

        public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();

        public DbSet<MatterType> MatterTypes => Set<MatterType>();

        public DbSet<MatterArea> MatterAreas => Set<MatterArea>();

        public DbSet<CourtSittingInCity> CourtSittingInCities => Set<CourtSittingInCity>();

        public DbSet<CourtGeographicalJurisdiction> CourtGeographicalJurisdictions => Set<CourtGeographicalJurisdiction>();

        public DbSet<Matter> Matters => Set<Matter>();

        public DbSet<MatterContact> MatterContacts => Set<MatterContact>();

        public DbSet<TaskType> TaskTypes => Set<TaskType>();

        public DbSet<Domain.Entities.Tasks.InnerTask> Tasks => Set<Domain.Entities.Tasks.InnerTask>();

        public DbSet<TaskAssignedContact> TaskAssignedContacts => Set<TaskAssignedContact>();

        public DbSet<Note> Notes => Set<Note>();

        public DbSet<NoteNotification> NoteNotifications => Set<NoteNotification>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            base.OnModelCreating(builder);
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
