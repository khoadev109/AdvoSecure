using AdvoSecure.Common.Persistance;
using AdvoSecure.Domain.Entities;

namespace AdvoSecure.Domain.Interfaces.Repositories
{
    public interface ITenantDirectoryRepository : IRepository<TenantDirectory>
    {
        Task<TenantDirectory> CreateAsync(TenantSetting tenant, TenantUser user, string userName);
    }
}
