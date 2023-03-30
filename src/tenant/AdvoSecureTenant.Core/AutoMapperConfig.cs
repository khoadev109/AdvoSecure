using AdvoSecureTenant.Core.Persistance.Entities;
using AdvoSecureTenant.Core.Services.Dtos;
using Microsoft.Extensions.DependencyInjection;

namespace AdvoSecureTenant.Core
{
    public static class AutoMapperConfig
    {
        public static IServiceCollection AddMappers(this IServiceCollection services)
        {
            services.AddAutoMapper(config =>
            {
                config.CreateMap<Tenant, TenantDto>().ReverseMap();
            });

            return services;
        }
    }
}
