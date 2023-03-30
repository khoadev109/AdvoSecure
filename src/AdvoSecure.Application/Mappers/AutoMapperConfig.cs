using AdvoSecure.Application.Dtos;
using AdvoSecure.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace AdvoSecure.Application.Mappers
{
    public static class AutoMapperConfig
    {
        public static IServiceCollection AddMappers(this IServiceCollection services)
        {
            services.AddAutoMapper(config =>
            {
                config.CreateMap<User, UserDto>().ReverseMap()
                    .ForMember(x => x.Id, x => x.Ignore())
                    .ForMember(x => x.ModifiedBy, x => x.Ignore())
                    .ForMember(x => x.ModifiedDateTime, x => x.Ignore())
                    .ForMember(x => x.DeletedBy, x => x.Ignore())
                    .ForMember(x => x.DeletedDateTime, x => x.Ignore());

                config.CreateMap<Tenant, TenantDto>().ReverseMap()
                    .ForMember(x => x.Id, x => x.Ignore())
                    .ForMember(x => x.ModifiedBy, x => x.Ignore())
                    .ForMember(x => x.ModifiedDateTime, x => x.Ignore())
                    .ForMember(x => x.DeletedBy, x => x.Ignore())
                    .ForMember(x => x.DeletedDateTime, x => x.Ignore());
            });

            return services;
        }
    }
}
