using AdvoSecure.Domain.Entities;

namespace AdvoSecure.Domain.Interfaces.Repositories
{
    public interface IRefreshTokenRepository
    {
        Type DbContextType { get; }

        Task SaveAsync(RefreshToken refreshToken);

        Task DeleteAsync(RefreshToken refreshToken);

        Task<RefreshToken> GetByUserAndTenantIdentifierAsync(Guid userIdentifier, Guid tenantIdentifier);
    }
}
