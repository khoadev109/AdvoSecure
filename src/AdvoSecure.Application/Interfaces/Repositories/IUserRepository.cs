using AdvoSecure.Domain.Entities;
using AdvoSecure.Security;

namespace AdvoSecure.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<bool> CheckPasswordAsync(string userName, string password);

        Task<TenantUser> FindByEmailAsync(string userName);

        Task<TenantUser> FindByUserIdentifierAsync(Guid userIdentifier);

        Task<TenantUser> CreateAsync(RegisterRequest request);

        Task<TenantUser> SaveAsync(TenantUser user);

        Task<IQueryable<TenantUser>> GetAllAsync();
    }
}
