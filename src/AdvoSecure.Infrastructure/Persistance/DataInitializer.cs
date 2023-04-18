using AdvoSecure.Infrastructure.Persistance.App;
using AdvoSecure.Infrastructure.Persistance.Tenant;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AdvoSecure.Infrastructure.Persistance
{
    public static class DataInitializer
    {
        public async static Task BootstrapPostgres(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<MgmtDbContext>();
            var hostEnvironment = services.GetRequiredService<IHostEnvironment>();

            if (context.Database.IsNpgsql())
            {
                await context.Database.MigrateAsync();
            }

            if (hostEnvironment?.IsDevelopment() ?? false)
            {
                await ASMgmtDataSeed.SeedAsMgmtTables(context);
            }
        }

        public static async Task SetConnectionStringAndRunMigration(this ApplicationDbContext dbContext, string connectionString)
        {
            if (dbContext.Database.IsNpgsql())
            {
                var dbBoostrapped = await dbContext.Database.CanConnectAsync();

                if (!dbBoostrapped)
                {
                    dbContext.Database.SetConnectionString(connectionString);

                    await dbContext.Database.MigrateAsync();

                    await ApplicationDataSeed.SeedAsAppTables(dbContext);
                }
            }
        }
    }
}
