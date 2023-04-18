using AdvoSecure.Domain.Entities;

namespace AdvoSecure.Application.Interfaces.Repositories
{
    public interface ITenantRepository
    {
        Task<TenantSetting> GetAsync(Guid tenantIdentifier);

        Task<TenantSetting> GetAdminAsync(Guid identifier);

        Task<TenantSetting> GetAdminAsync(int id);

        Task<TenantSetting?> GetByUserIdentifierAsync(Guid userIdentifier);

        Task<TenantSetting?> GetByUserEmailAsync(string email);

        IEnumerable<TenantSetting> GetAllTenants();

        Task<TenantSetting?> GetByIdAsync(int id);

        Task<TenantSetting> CreateAsync(Guid adminTenantIdentifier);
    }
}
