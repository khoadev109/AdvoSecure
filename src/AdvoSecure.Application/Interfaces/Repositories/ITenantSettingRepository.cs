using AdvoSecure.Common.Persistance;
using AdvoSecure.Domain.Entities;

namespace AdvoSecure.Application.Interfaces.Repositories
{
    public interface ITenantSettingRepository : IRepository<TenantSetting>
    {
        Task<TenantSetting> GetByUserIdentifierAsync(Guid userIdentifier);

        Task<TenantSetting> GetByUserEmailAsync(string email);

        Task<TenantSetting> GetAdminAsync(Guid identifier);

        Task<TenantSetting> GetAdminAsync(int id);

        Task<IEnumerable<TenantSetting>> GetAllAsync();

        Task<TenantSetting> CreateAsync(Guid adminTenantIdentifier);
    }
}
