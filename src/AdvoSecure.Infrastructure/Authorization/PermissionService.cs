using AdvoSecure.Application.Interfaces;
using AdvoSecure.Infrastructure.Persistance.Management;

namespace AdvoSecure.Infrastructure.Authorization
{
    public class PermissionService : IPermissionService
    {
        private readonly IMgmtUnitOfWork _mgmtUnitOfWork;

        public PermissionService(IMgmtUnitOfWork mgmtUnitOfWork)
        {
            _mgmtUnitOfWork = mgmtUnitOfWork;
        }

        public async Task<bool> CheckAsTenantAdminAsync(Guid tenantIndentifier)
        {
            bool existed = await _mgmtUnitOfWork.TenantSettingRepository.ExistAsync(t => t.TenantIdentifier == tenantIndentifier && !t.AdminId.HasValue);

            return existed;
        }

        public async Task<bool> CheckAsAppUserTenant(Guid tenantIndentifier)
        {
            bool existing = await _mgmtUnitOfWork.TenantSettingRepository.ExistAsync(t => t.TenantIdentifier == tenantIndentifier && t.AdminId.HasValue);

            return existing;
        }
    }
}
