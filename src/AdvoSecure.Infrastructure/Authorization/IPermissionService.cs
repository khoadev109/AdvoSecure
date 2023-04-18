namespace AdvoSecure.Infrastructure.Authorization
{
    public interface IPermissionService
    {
        Task<bool> CheckAsTenantAdminAsync(Guid tenantIndentifier);

        Task<bool> CheckAsAppUserTenant(Guid tenantIndentifier);

        Task SetAppUserConnectionString(Guid tenantIndentifier);
    }
}
