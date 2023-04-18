namespace AdvoSecure.Application.Interfaces.Repositories
{
    public interface IRefreshTokenRepositoryFactory
    {
        IRefreshTokenRepository GetInstance(Type dbContext);
    }
}
