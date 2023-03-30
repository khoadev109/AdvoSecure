using AdvoSecure.Application.Dtos;

namespace AdvoSecure.Application.Interfaces.Services
{
    public interface ITenantService
    {
        Task<TenantDto> CreateTenantFromTenantBase(OrgInitializationRequestDto orgRequestDto);

        Task<TenantDto> GetTenant();
    }
}
