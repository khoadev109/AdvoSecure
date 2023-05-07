using AdvoSecure.Common.Persistance;
using AdvoSecure.Domain.Entities;
using AdvoSecure.Domain.Interfaces.Requests;

namespace AdvoSecure.Domain.Interfaces.Repositories
{
    public interface ITenantUserRepository: IRepository<TenantUser>
    {
        Task<bool> CheckPasswordAsync(string userName, string password);

        Task<TenantUser> CreateAsync(RegisterRequest request, string userName);
    }
}
