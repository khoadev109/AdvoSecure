using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AdvoSecureTenant.Core.Persistance
{
    public static class PersistanceDependenciesConfig
    {
        public static IServiceCollection AddTenantDbContext(this IServiceCollection services)
        {
            var configuration = services.BuildServiceProvider().GetService<IConfiguration>()!;
            var connectionString = configuration.GetConnectionString("TenantServer");

            services.AddDbContext<TenantDbContext>((options) =>
            {
                options.UseNpgsql(connectionString, so => so.MigrationsAssembly(typeof(TenantDbContext).Assembly.FullName));
            });

            return services;
        }
    }
}
