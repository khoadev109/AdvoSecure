using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AdvoSecureTenant.Core.Persistance
{
    public static class TenantDataInitialization
    {
        public async static Task BootstrapPostgres(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<TenantDbContext>();
            var hostEnvironment = services.GetRequiredService<IHostEnvironment>();

            if (context.Database.IsNpgsql())
            {
                await context.Database.MigrateAsync();
            }

            await TenantDataSeed.SeedTenantTables(context);

            if (hostEnvironment?.IsDevelopment() ?? false)
            {
                // To do for development
            }
        }
    }
}
