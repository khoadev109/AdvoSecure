using AdvoSecure.Application.Interfaces.Services;
using AdvoSecure.Domain.Entities;
using AdvoSecure.Infrastructure.Persistance.App;
using AdvoSecure.Infrastructure.Persistance.Management;
using AdvoSecure.Security;
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

                await RegisterDefaultAppUser(services);
            }
        }

        private static async Task RegisterDefaultAppUser(IServiceProvider serviceProvider)
        {
            try
            {
                var context = serviceProvider.GetRequiredService<MgmtDbContext>();

                TenantSetting tenantAdmin = await context.TenantSettings.FirstOrDefaultAsync(x => !x.AdminId.HasValue);

                if (tenantAdmin == null)
                {
                    return;
                }

                var tenantService = serviceProvider.GetRequiredService<ITenantService>();

                var request = new AuthRegisterRequest
                {
                    Email = "gj.dijkstra@totaldesk.nl",
                    DisplayName = "TotalDesk",
                    Password = "password",
                    FirstName = "Total",
                    LastName = "Desk",
                    TenantAdminIdentifier = tenantAdmin.TenantIdentifier
                };

                await tenantService.RegisterUserAsync(request, "TOAA");
            }
            catch (Exception ex)
            {
                return;
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
