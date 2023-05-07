namespace AdvoSecure.Domain.Interfaces.Repositories
{
    public interface IRefreshTokenRepositoryFactory
    {
        IRefreshTokenRepository GetInstance(Type dbContext);
    }
}
