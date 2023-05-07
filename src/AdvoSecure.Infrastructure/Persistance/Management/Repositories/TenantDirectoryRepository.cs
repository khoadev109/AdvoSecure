using AdvoSecure.Domain.Interfaces.Repositories;
using AdvoSecure.Common.Persistance;
using AdvoSecure.Domain.Entities;

namespace AdvoSecure.Infrastructure.Persistance.Tenant.Repositories
{
    public class TenantDirectoryRepository : Repository<TenantDirectory>, ITenantDirectoryRepository
    {
        public TenantDirectoryRepository(MgmtDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<TenantDirectory> CreateAsync(TenantSetting tenant, TenantUser user, string userName)
        {
            var tenantDirectory = new TenantDirectory
            {
                Tenant = tenant,
                User = user,
                CreatedBy = userName
            };

            tenant.TenantDirectories.Add(tenantDirectory);

            user.TenantDirectories.Add(tenantDirectory);

            return tenantDirectory;
        }
    }
}
