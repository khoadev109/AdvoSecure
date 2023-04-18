using AdvoSecure.Domain.Entities;

namespace AdvoSecure.Application.Interfaces.Repositories
{
    public interface IDirectoryRepository
    {
        Task<TenantDirectory> CreateAsync(TenantSetting tenant, TenantUser user);
    }
}
