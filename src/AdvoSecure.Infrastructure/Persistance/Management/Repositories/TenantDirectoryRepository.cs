using AdvoSecure.Common.Persistance;
using AdvoSecure.Domain.Entities;
using AdvoSecure.Domain.Interfaces.Repositories;

namespace AdvoSecure.Infrastructure.Persistance.Management.Repositories
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
