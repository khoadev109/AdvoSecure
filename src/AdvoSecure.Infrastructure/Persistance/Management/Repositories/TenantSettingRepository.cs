using AdvoSecure.Domain.Interfaces.Repositories;
using AdvoSecure.Common.Persistance;
using AdvoSecure.Domain.Entities;
using AdvoSecure.Infrastructure.Persistance.Tenant;
using Microsoft.EntityFrameworkCore;

namespace AdvoSecure.Infrastructure.Persistance.Management.Repositories
{
    public class TenantSettingRepository : Repository<TenantSetting>, ITenantSettingRepository
    {
        public TenantSettingRepository(MgmtDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<TenantSetting> GetByUserIdentifierAsync(Guid userIdentifier)
        {
            TenantSetting tenant = await GetQueryable().Include(x => x.TenantDirectories).ThenInclude(x => x.User).FirstOrDefaultAsync(x => x.TenantDirectories.Any(y => y.User.UserIdentifier == userIdentifier));

            return tenant;
        }

        public async Task<TenantSetting> GetByUserEmailAsync(string email)
        {
            TenantSetting tenant = await GetQueryable().Include(x => x.TenantDirectories).ThenInclude(x => x.User).FirstOrDefaultAsync(x => x.TenantDirectories.Any(y => y.User.Email == email));

            return tenant;
        }

        public async Task<TenantSetting> GetAdminAsync(Guid identifier)
        {
            TenantSetting tenant = await GetAsync(x => x.TenantIdentifier == identifier && !x.AdminId.HasValue);

            return tenant;
        }

        public async Task<TenantSetting> GetAdminAsync(int id)
        {
            TenantSetting tenant = await GetAsync(x => x.Id == id && !x.AdminId.HasValue);

            return tenant;
        }

        public async Task<IEnumerable<TenantSetting>> GetAllAsync()
        {
            IEnumerable<TenantSetting> tenants = await GetAllAsync(x => x.AdminId.HasValue);

            return tenants;
        }

        public async Task<TenantSetting> CreateAsync(Guid adminTenantIdentifier)
        {
            TenantSetting tenantAdmin = await GetAdminAsync(adminTenantIdentifier);

            if (tenantAdmin == null)
            {
                return null;
            }

            var tenantIdentifier = Guid.NewGuid();

            var tenant = new TenantSetting
            {
                TenantIdentifier = tenantIdentifier,
                Name = $"tenant_{tenantIdentifier}",
                SchemaName = $"db_{tenantIdentifier}",
                ConnectionString = $"Server=localhost;Database=ASAUT_{tenantIdentifier};Port=5432;User Id=postgres;Password=password;Ssl Mode=Prefer;Trust Server Certificate=true",
                AdminId = tenantAdmin.Id,
                CreatedBy = "TOAA"
            };

            await Context.AddAsync(tenant);

            return tenant;
        }
    }
}
