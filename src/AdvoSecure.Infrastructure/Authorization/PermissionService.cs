﻿using AdvoSecure.Infrastructure.Persistance.App;
using AdvoSecure.Infrastructure.Persistance.Tenant;
using Microsoft.EntityFrameworkCore;

namespace AdvoSecure.Infrastructure.Authorization
{
    public class PermissionService : IPermissionService
    {
        private readonly MgmtDbContext _tenantDbContext;
        private readonly ApplicationDbContext _appDbContext;

        public PermissionService(MgmtDbContext tenantDbContext, ApplicationDbContext appDbContext)
        {
            _tenantDbContext = tenantDbContext;
            _appDbContext = appDbContext;
        }

        public async Task<bool> CheckAsTenantAdminAsync(Guid tenantIndentifier)
        {
            bool existed = await _tenantDbContext.TenantSettings.AnyAsync(t => t.TenantIdentifier == tenantIndentifier && !t.AdminId.HasValue);

            return existed;
        }

        public async Task<bool> CheckAsAppUserTenant(Guid tenantIndentifier)
        {
            bool existing = await _tenantDbContext.TenantSettings?.AnyAsync(t => t.TenantIdentifier == tenantIndentifier && t.AdminId.HasValue);

            return existing;
        }
    }
}
