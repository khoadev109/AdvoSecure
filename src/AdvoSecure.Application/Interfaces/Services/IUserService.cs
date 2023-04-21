using AdvoSecure.Application.Dtos;
using AdvoSecure.Security;

namespace AdvoSecure.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<bool> CheckPasswordAsync(string userName, string password);

        Task<TenantUserDto> FindByEmailAsync(string userName);

        Task<TenantUserDto> FindByUserIdentifierAsync(Guid userIdentifier);

        Task<TenantUserDto> RegisterUserAsync(RegisterRequest request);

        Task<ApplicationUser> UpdateAppUserProfile(AppUserProfileRequestDto request);

        Task<TenantUserDto> UpdateTenantUser(AppUserProfileRequestDto request);

        Task<IEnumerable<TenantUserDto>> GetAllUsersAsync();

        Task<RefreshTokenDto> GetTenantRefreshTokenAsync(Guid userIdentifier, Guid tenantIdentifier);

        Task SaveTenantRefreshTokenAsync(RefreshTokenDto dto);

        Task<RefreshTokenDto> GetAppRefreshTokenAsync(Guid userIdentifier, Guid tenantIdentifier);

        Task SaveAppRefreshTokenAsync(RefreshTokenDto dto);

        Task SetAppUserConnectionString(string userEmail);
    }
}
