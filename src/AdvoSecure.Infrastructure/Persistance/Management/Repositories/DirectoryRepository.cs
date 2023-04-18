using AdvoSecure.Application.Interfaces.Repositories;
using AdvoSecure.Domain.Entities;

namespace AdvoSecure.Infrastructure.Persistance.Tenant.Repositories
{
    public class DirectoryRepository : IDirectoryRepository
    {
        private readonly MgmtDbContext _dbContext;

        public DirectoryRepository(MgmtDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TenantDirectory> CreateAsync(TenantSetting tenant, TenantUser user)
        {
            var tenantDirectory = new TenantDirectory
            {
                Tenant = tenant,
                User = user,
                CreatedBy = "TOAA"
            };

            tenant.TenantDirectories.Add(tenantDirectory);

            user.TenantDirectories.Add(tenantDirectory);

            await _dbContext.SaveChangesAsync();

            return tenantDirectory;
        }
    }
}
