using AdvoSecure.Application.Dtos;
using AdvoSecure.Domain.Entities;

namespace AdvoSecure.Application.Interfaces.Services
{
    public interface ITenantService
    {
        Task<TenantSettingDto> GetCurrentTenant(Guid identifier, Guid adminIdentifier);

        Task<TenantSettingDto> GetTenantAdminByUserIdentifier(Guid userIdentifier);

        Task<TenantSettingDto> GetTenantByUserIdentifier(Guid userIdentifier);

        Task<TenantSettingDto> GetTenantById(int id);

        Task<TenantSettingDto> GetTenantAdmin(Guid adminIdentifier);

        Task<TenantSettingDto> GetTenantAdmin(int id);

        IEnumerable<TenantSettingDto> GetAllTenants();
    }
}
