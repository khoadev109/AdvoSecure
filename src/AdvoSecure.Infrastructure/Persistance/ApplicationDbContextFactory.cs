using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AdvoSecure.Infrastructure.Persistance
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseNpgsql("Server=localhost;Database=advosecuretestdb;Port=5432;User Id=postgres;Password=password;Ssl Mode=Prefer;Trust Server Certificate=true");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
