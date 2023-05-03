using AdvoSecure.Application.Dtos;
using AdvoSecure.Common;
using AdvoSecure.Security;

namespace AdvoSecure.Application.Interfaces.Services
{
    public interface ITenantService
    {
        Task<ServiceResult<TenantSettingDto>> GetCurrentTenantAsync(Guid identifier, Guid adminIdentifier);

        Task<ServiceResult<TenantSettingDto>> GetTenantAdminByUserIdentifierAsync(Guid userIdentifier);

        Task<ServiceResult<TenantSettingDto>> GetTenantByUserIdentifierAsync(Guid userIdentifier);

        Task<ServiceResult<TenantSettingDto>> GetTenantByIdAsync(int id);

        Task<ServiceResult<TenantSettingDto>> GetTenantAdminAsync(Guid adminIdentifier);

        Task<ServiceResult<TenantSettingDto>> GetTenantAdminAsync(int id);

        Task<ServiceResult<IEnumerable<TenantSettingDto>>> GetAllTenantsAsync();

        Task<ServiceResult<TenantUserDto>> RegisterUserAsync(RegisterRequest request, string userName);
    }
}
