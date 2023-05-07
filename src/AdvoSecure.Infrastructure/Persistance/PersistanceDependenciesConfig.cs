using AdvoSecure.Application.Interfaces;
using AdvoSecure.Domain.Interfaces;
using AdvoSecure.Domain.Interfaces.Repositories;
using AdvoSecure.Infrastructure.Persistance.App;
using AdvoSecure.Infrastructure.Persistance.App.Repositories;
using AdvoSecure.Infrastructure.Persistance.Application;
using AdvoSecure.Infrastructure.Persistance.Application.Repositories;
using AdvoSecure.Infrastructure.Persistance.Management;
using AdvoSecure.Infrastructure.Persistance.Management.Repositories;
using AdvoSecure.Infrastructure.Persistance.Tenant;
using AdvoSecure.Infrastructure.Persistance.Tenant.Repositories;
using AdvoSecure.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AdvoSecure.Infrastructure.Persistance
{
    public static class PersistanceDependenciesConfig
    {
        public static IServiceCollection AddAppDbContext(this IServiceCollection services)
        {
            var configuration = services.BuildServiceProvider().GetService<IConfiguration>()!;
            var connectionString = configuration.GetConnectionString("AppServer");

            services.AddDbContext<ApplicationDbContext>((options) =>
            {
                options.UseNpgsql(connectionString, so => so.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
            });

            return services;
        }

        public static IServiceCollection AddMgmtDbContext(this IServiceCollection services)
        {
            var configuration = services.BuildServiceProvider().GetService<IConfiguration>()!;
            var connectionString = configuration.GetConnectionString("MgmtServer");

            services.AddDbContext<MgmtDbContext>((options) =>
            {
                options.UseNpgsql(connectionString, so => so.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
            });

            return services;
        }

        public static IServiceCollection AddIdentityDb(this IServiceCollection services)
        {
            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password = new PasswordOptions
                {
                    RequiredLength = 4,
                    RequireNonAlphanumeric = false,
                    RequireDigit = false,
                    RequireLowercase = false,
                    RequireUppercase = false,
                    RequiredUniqueChars = 0
                };
            });

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITenantSettingRepository, TenantSettingRepository>();
            services.AddScoped<ITenantUserRepository, TenantUserRepository>();
            services.AddScoped<ITenantDirectoryRepository, TenantDirectoryRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IMatterRepository, MatterRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<IRefreshTokenRepository, Tenant.Repositories.RefreshTokenRepository>();
            services.AddScoped<IRefreshTokenRepository, App.Repositories.RefreshTokenRepository>();
            services.AddTransient<IRefreshTokenRepositoryFactory, RefreshTokenRepositoryFactory>();

            return services;
        }

        public static IServiceCollection AddUnitOfWorks(this IServiceCollection services)
        {
            services.AddScoped<IMgmtUnitOfWork, MgmtUnitOfWork>();
            services.AddScoped<IAppUnitOfWork, AppUnitOfWork>();

            return services;
        }

        public static IServiceCollection AddPersistance(this IServiceCollection services)
        {
            services.AddMgmtDbContext();
            services.AddAppDbContext();
            services.AddIdentityDb();
            services.AddRepositories();
            services.AddUnitOfWorks();

            return services;
        }
    }
}
