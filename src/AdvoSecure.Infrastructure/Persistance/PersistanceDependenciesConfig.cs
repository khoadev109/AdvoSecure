using AdvoSecure.Application.Interfaces.Repositories;
using AdvoSecure.Infrastructure.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AdvoSecure.Infrastructure.Persistance
{
    public static class PersistanceDependenciesConfig
    {
        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services)
        {
            var configuration = services.BuildServiceProvider().GetService<IConfiguration>()!;
            var connectionString = configuration.GetConnectionString("PostgressServer");

            services.AddDbContext<ApplicationDbContext>((options) =>
            {
                options.UseNpgsql(connectionString, so => so.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
            });

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITenantRepository, TenantRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
