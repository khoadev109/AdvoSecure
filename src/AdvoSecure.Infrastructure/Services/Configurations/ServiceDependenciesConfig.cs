using AdvoSecure.Application.Interfaces.Services;
using AdvoSecure.Infrastructure.Persistance;
using Microsoft.Extensions.DependencyInjection;

namespace AdvoSecure.Infrastructure.Services.Configurations
{
    public static class ServiceDependenciesConfig
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITenantService, TenantService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICommonService, CommonService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IMatterService, MatterService>();
            services.AddScoped<INoteService, NoteService>();

            return services;
        }
    }
}
