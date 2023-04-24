using AdvoSecure.Infrastructure.Persistance.App;
using AdvoSecure.Infrastructure.Persistance.Tenant;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AdvoSecure.Infrastructure.Persistance
{
    public static class DataInitializer
    {
        private static SemaphoreSlim _semaphoreSlim = new(1, 1);

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

        public static async Task SetConnectionStringAndRunMigration(this ApplicationDbContext appDbContext, string connectionString)
        {
            await _semaphoreSlim.WaitAsync();

            try
            {
                var dbBoostrapped = await appDbContext.Database.CanConnectAsync();

                if (!dbBoostrapped)
                {
                    appDbContext.Database.SetConnectionString(connectionString);

                    await appDbContext.Database.MigrateAsync();

                    await ApplicationDataSeed.SeedAsAppTables(appDbContext);
                }
            }
            finally
            {
                _semaphoreSlim.Release();
            }
        }
    }
}
