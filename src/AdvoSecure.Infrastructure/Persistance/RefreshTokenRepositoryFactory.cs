using AdvoSecure.Domain.Interfaces.Repositories;

namespace AdvoSecure.Infrastructure.Persistance
{
    public class RefreshTokenRepositoryFactory : IRefreshTokenRepositoryFactory
    {
        private readonly IEnumerable<IRefreshTokenRepository> _refreshTokenRepositories;

        public RefreshTokenRepositoryFactory(IEnumerable<IRefreshTokenRepository> refreshTokenRepositories)
        {
            _refreshTokenRepositories = refreshTokenRepositories;
        }

        public IRefreshTokenRepository GetInstance(Type dbContext)
        {
            return _refreshTokenRepositories.FirstOrDefault(x => x.DbContextType == dbContext);
        }
    }
}
