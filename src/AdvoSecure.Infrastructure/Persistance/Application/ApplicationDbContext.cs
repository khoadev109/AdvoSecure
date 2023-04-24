using AdvoSecure.Domain.Entities;
using AdvoSecure.Domain.Entities.BillingEntities;
using AdvoSecure.Domain.Entities.ContactEntities;
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

        public DbSet<Case> Cases => Set<Case>();

        public DbSet<Country> Countries => Set<Country>();

        public DbSet<Contact> Contacts => Set<Contact>();

        public DbSet<CompanyLegalStatus> CompanyLegalStatuses => Set<CompanyLegalStatus>();

        public DbSet<ContactCivilStatus> ContactCivilStatuses => Set<ContactCivilStatus>();

        public DbSet<ContactIdType> ContactIdTypes => Set<ContactIdType>();

        public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            base.OnModelCreating(builder);
        }
    }
}
