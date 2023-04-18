using AdvoSecure.Application.Dtos;
using AdvoSecure.Application.Interfaces.Repositories;
using AdvoSecure.Domain.Entities;
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

        public async Task SaveAsync(RefreshTokenDto dto)
        {
            RefreshToken refreshToken = _mapper.Map<RefreshToken>(dto);

            await _dbContext.RefreshTokens.AddAsync(refreshToken);

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(RefreshTokenDto dto)
        {
            RefreshToken refreshToken = await _dbContext.RefreshTokens.SingleOrDefaultAsync(x => x.UserIdentifier == dto.UserIdentifier && x.TenantIdentifier == dto.TenantIdentifier);

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
