using AdvoSecure.Application.Interfaces.Services;
using AdvoSecure.Infrastructure.Persistance;
using Microsoft.Extensions.DependencyInjection;

namespace AdvoSecure.Infrastructure.Services
{
    public static class ServiceDependenciesConfig
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITenantService, TenantService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICaseService, CaseService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<ICommonService, CommonService>();

            return services;
        }
    }
}
