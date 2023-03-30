using AdvoSecure.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AdvoSecure.Infrastructure.Persistance
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
