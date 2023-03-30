using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AdvoSecure.Infrastructure.Persistance
{
    public static class AppDataInitialization
    {
		public async static Task BootstrapPostgres(this IHost host)
		{
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<ApplicationDbContext>();
            var hostEnvironment = services.GetRequiredService<IHostEnvironment>();

            if (context.Database.IsNpgsql())
            {
                await context.Database.MigrateAsync();
            }

            if (hostEnvironment?.IsDevelopment() ?? false)
            {
            }
        }
	}
}
