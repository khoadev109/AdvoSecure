using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AdvoSecure.Infrastructure.Persistance.Management
{
    public class MgmtDbContextFactory : IDesignTimeDbContextFactory<MgmtDbContext>
    {
        public MgmtDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MgmtDbContext>();
            optionsBuilder.UseNpgsql("Server=localhost;Database=ASMGMT;Port=5432;User Id=postgres;Password=password;Ssl Mode=Prefer;Trust Server Certificate=true");

            return new MgmtDbContext(optionsBuilder.Options);
        }
    }
}
