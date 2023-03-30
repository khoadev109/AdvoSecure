using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AdvoSecureTenant.Core.Persistance
{
    public class TenantDbContextFactory : IDesignTimeDbContextFactory<TenantDbContext>
    {
        public TenantDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TenantDbContext>();
            optionsBuilder.UseNpgsql("Server=localhost;Database=advosecuretenantdb;Port=5432;User Id=postgres;Password=password;Ssl Mode=Prefer;Trust Server Certificate=true");

            return new TenantDbContext(optionsBuilder.Options);
        }
    }
}
