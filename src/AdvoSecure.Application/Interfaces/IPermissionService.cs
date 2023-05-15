namespace AdvoSecure.Application.Interfaces
{
    public interface IPermissionService
    {
        Task<bool> CheckAsTenantAdminAsync(Guid tenantIndentifier);

        Task<bool> CheckAsAppUserTenant(Guid tenantIndentifier);
    }
}
