using AdvoSecure.Application.Dtos;
using AdvoSecure.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdvoSecure.Application.Interfaces.Repositories
{
    public interface IRefreshTokenRepository
    {
        Type DbContextType { get; }

        Task SaveAsync(RefreshTokenDto dto);

        Task DeleteAsync(RefreshTokenDto dto);

        Task<RefreshToken> GetByUserAndTenantIdentifierAsync(Guid userIdentifier, Guid tenantIdentifier);
    }
}
