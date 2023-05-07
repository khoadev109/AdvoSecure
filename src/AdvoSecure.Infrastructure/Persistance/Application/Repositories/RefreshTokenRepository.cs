using AdvoSecure.Domain.Entities;
using AdvoSecure.Domain.Interfaces.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AdvoSecure.Infrastructure.Persistance.App.Repositories
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public RefreshTokenRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Type DbContextType => typeof(ApplicationDbContext);

        public async Task SaveAsync(RefreshToken refreshToken)
        {
            await _dbContext.RefreshTokens.AddAsync(refreshToken);

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(RefreshToken refreshToken)
        {
            RefreshToken existingRefreshToken = await _dbContext.RefreshTokens.SingleOrDefaultAsync(x => x.UserIdentifier == refreshToken.UserIdentifier && x.TenantIdentifier == refreshToken.TenantIdentifier);

            if (refreshToken != null)
            {
                _dbContext.Remove(refreshToken);

                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<RefreshToken> GetByUserAndTenantIdentifierAsync(Guid userIdentifier, Guid tenantIdentifier)
        {
            var refreshToken = await _dbContext.RefreshTokens.SingleOrDefaultAsync(x => x.UserIdentifier == userIdentifier && x.TenantIdentifier == tenantIdentifier);

            return refreshToken;
        }
    }
}
