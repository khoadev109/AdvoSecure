using AdvoSecure.Api.Authentication;
using AdvoSecure.Application.Interfaces;
using AdvoSecure.Common;
using AdvoSecure.Common.Persistance;
using AdvoSecure.Common.Swagger;
using AdvoSecure.Domain.Interfaces;
using AdvoSecure.Domain.Interfaces.Repositories;
using AdvoSecure.Infrastructure.Authorization;
using AdvoSecure.Infrastructure.Persistance.App;
using AdvoSecure.Infrastructure.Persistance.App.Repositories;
using AdvoSecure.Infrastructure.Persistance.Application;
using AdvoSecure.Infrastructure.Persistance.Application.Repositories;
using AdvoSecure.Infrastructure.Persistance.Management;
using AdvoSecure.Infrastructure.Persistance.Management.Repositories;
using AdvoSecure.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AdvoSecure.Infrastructure
{
    public class InfrastructureServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddDebug();
                builder.SetMinimumLevel(LogLevel.Information);
            });

            services.Configure<FormOptions>(o =>
            {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });

            var validOrigins = configuration.GetSection("Client:ValidOrigins").Get<string[]>() ?? Array.Empty<string>();

            services.AddCors(options =>
            {
                options.AddPolicy(configuration["CorsPolicy"], builder => builder
                    .WithOrigins(validOrigins)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddDistributedMemoryCache();
            services.AddHttpContextAccessor();
            services.AddEndpointsApiExplorer();
            services.AddMemoryCache();
            services.AddSignalR();
            services.AddSwagger("AdvoSecure");
            services.AddScoped<JwtResolver>();
            services.AddScoped<RsaResolver>();
            services.AddSingleton<CacheProvider>();
            services.AddAdvoAuthentication(configuration);
            services.AddPermissions();

            services.AddMgmtDbContext();
            services.AddAppDbContext();
            services.AddIdentityDb();
            services.AddRepositories();
            services.AddUnitOfWorks();
        }
    }

    public static class DependencyInjection
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

            return services;
        }

        public static IServiceCollection AddUnitOfWorks(this IServiceCollection services)
        {
            services.AddScoped<IMgmtUnitOfWork, MgmtUnitOfWork>();
            services.AddScoped<IAppUnitOfWork, AppUnitOfWork>();

            return services;
        }

        public static IServiceCollection AddAdvoAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new JwtResolver(configuration).GetTokenParameters();
            });

            return services;
        }

        public static IServiceCollection AddPermissions(this IServiceCollection services)
        {
            services.AddAuthorization();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();
            services.AddSingleton<IAuthorizationPolicyProvider, PermissionAuthorizationPolicyProvider>();

            return services;
        }
    }
}
