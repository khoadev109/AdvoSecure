using AdvoSecure.Application.Dtos;
using AdvoSecure.Common;
using AdvoSecure.Security;

namespace AdvoSecure.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<ServiceResult<bool>> CheckPasswordAsync(string userName, string password);

        Task<ServiceResult<TenantUserDto>> FindByEmailAsync(string userName);

        Task<ServiceResult<TenantUserDto>> FindByUserIdentifierAsync(Guid userIdentifier);

        Task<ServiceResult<IEnumerable<TenantUserDto>>> GetAllUsersAsync();

        Task<ServiceResult<ApplicationUser>> UpdateAppUserProfile(AppUserProfileRequestDto request);

        Task<ServiceResult<TenantUserDto>> UpdateTenantUser(AppUserProfileRequestDto request);

        Task<ServiceResult> SetAppUserConnectionString(string userEmail);


        Task<RefreshTokenDto> GetTenantRefreshTokenAsync(Guid userIdentifier, Guid tenantIdentifier);

        Task SaveTenantRefreshTokenAsync(RefreshTokenDto dto);

        Task<RefreshTokenDto> GetAppRefreshTokenAsync(Guid userIdentifier, Guid tenantIdentifier);

        Task SaveAppRefreshTokenAsync(RefreshTokenDto dto);
    }
}
