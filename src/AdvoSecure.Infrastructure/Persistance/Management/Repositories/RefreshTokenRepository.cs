using AdvoSecure.Application.Dtos;
using AdvoSecure.Domain.Interfaces.Repositories;
using AdvoSecure.Domain.Entities;
using AdvoSecure.Infrastructure.Persistance.App;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AdvoSecure.Infrastructure.Persistance.Tenant.Repositories
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly MgmtDbContext _dbContext;
        private readonly IMapper _mapper;

        public RefreshTokenRepository(MgmtDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Type DbContextType => typeof(MgmtDbContext);

        public async Task SaveAsync(RefreshToken refreshToken)
        {
            await _dbContext.RefreshTokens.AddAsync(refreshToken);

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(RefreshToken refreshToken)
        {
            RefreshToken existingRefreshToken = await _dbContext.RefreshTokens.SingleOrDefaultAsync(x => x.UserIdentifier == refreshToken.UserIdentifier && x.TenantIdentifier == refreshToken.TenantIdentifier);

            if (existingRefreshToken != null)
            {
                _dbContext.Remove(existingRefreshToken);

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