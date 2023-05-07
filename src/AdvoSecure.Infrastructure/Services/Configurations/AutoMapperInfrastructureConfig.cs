using AdvoSecure.Application.Dtos;
using AdvoSecure.Application.Dtos.MatterDtos;
using AdvoSecure.Domain.Interfaces.Requests;
using AdvoSecure.Security;
using Microsoft.Extensions.DependencyInjection;

namespace AdvoSecure.Infrastructure.Services.Configurations
{
    public static class AutoMapperServiceConfig
    {
        public static IServiceCollection AddServiceMappers(this IServiceCollection services)
        {
            services.AddAutoMapper(config =>
            {
                config.CreateMap<MatterSearchRequestDto, MatterSearchRequest>();
                config.CreateMap<AuthRegisterRequest, RegisterRequest>();
                config.CreateMap<RefreshTokenDto, RefreshTokenRequest>();
            });

            return services;
        }
    }
}
