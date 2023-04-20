using AdvoSecure.Application.Interfaces.Repositories;
using AdvoSecure.Domain.Entities;
using AdvoSecure.Infrastructure.Persistance.Tenant;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Tsp;

namespace AdvoSecure.Infrastructure.Persistance.Management.Repositories
{
    public class TenantRepository : ITenantRepository
    {
        private readonly MgmtDbContext _dbContext;

        public TenantRepository(MgmtDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TenantSetting> GetAsync(Guid tenantIdentifier)
        {
            TenantSetting tenant = await _dbContext.TenantSettings.SingleOrDefaultAsync(x => x.TenantIdentifier == tenantIdentifier);

            return tenant;
        }

        public async Task<TenantSetting?> GetByUserIdentifierAsync(Guid userIdentifier)
        {
            var user = await _dbContext.TenantUsers.SingleOrDefaultAsync(x => x.UserIdentifier == userIdentifier);

            if (user == null)
            {
                return null;
            }

            TenantDirectory directory = await _dbContext.TenantDirectories.SingleOrDefaultAsync(x => x.UserId == user.Id);

            if (directory == null)
            {
                return null;
            }

            TenantSetting tenant = await _dbContext.TenantSettings.FindAsync(directory.TenantId);
            if (tenant == null)
            {
                return null;
            }

            return tenant;
        }

        public async Task<TenantSetting?> GetByUserEmailAsync(string email)
        {
            var user = await _dbContext.TenantUsers.SingleOrDefaultAsync(x => x.Email == email);

            if (user == null)
            {
                return null;
            }

            TenantDirectory directory = await _dbContext.TenantDirectories.SingleOrDefaultAsync(x => x.UserId == user.Id);

            if (directory == null)
            {
                return null;
            }

            TenantSetting tenant = await _dbContext.TenantSettings.FindAsync(directory.TenantId);
            if (tenant == null)
            {
                return null;
            }

            return tenant;
        }

        public async Task<TenantSetting?> GetByIdAsync(int id)
        {
            TenantSetting tenant = await _dbContext.TenantSettings.FindAsync(id);

            return tenant;
        }

        public async Task<TenantSetting> GetAdminAsync(Guid identifier)
        {
            TenantSetting tenant = await _dbContext.TenantSettings.SingleOrDefaultAsync(x => x.TenantIdentifier == identifier && !x.AdminId.HasValue);

            return tenant;
        }

        public async Task<TenantSetting> GetAdminAsync(int id)
        {
            TenantSetting tenant = await _dbContext.TenantSettings.SingleOrDefaultAsync(x => x.Id == id && !x.AdminId.HasValue);

            return tenant;
        }

        public IEnumerable<TenantSetting> GetAllTenants()
        {
            IEnumerable<TenantSetting> tenants = _dbContext.TenantSettings.Where(t => t.AdminId.HasValue).AsEnumerable();
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

            await _dbContext.TenantSettings.AddAsync(tenant);

            await _dbContext.SaveChangesAsync();

            return tenant;
        }



        

    }
}
