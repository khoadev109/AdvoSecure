using AdvoSecure.Infrastructure.Persistance.App;
using AdvoSecure.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace AdvoSecure.Infrastructure.Authorization
{
    public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public PermissionAuthorizationHandler(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected async override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            string? tenantAdminIdentifier = context.User.Claims.FirstOrDefault(x => x.Type == ClaimConstants.TenantAdminIdentifier)?.Value;

            if (!Guid.TryParse(tenantAdminIdentifier, out Guid parsedTenantAdminIdentifier))
            {
                return;
            }

            using IServiceScope scope = _serviceScopeFactory.CreateScope();

            IPermissionService permissionService = scope.ServiceProvider.GetRequiredService<IPermissionService>();

            if (requirement.Permission.ValidPermission(Permission.AsTenantAdmin))
            {
                bool isAdmin = await permissionService.CheckAsTenantAdminAsync(parsedTenantAdminIdentifier);
                if (isAdmin)
                {
                    context.Succeed(requirement);
                }
            }

            if (requirement.Permission.ValidPermission(Permission.AsAppUser))
            {
                string? tenantIdentifier = context.User.Claims.FirstOrDefault(x => x.Type == ClaimConstants.TenantIdentifier)?.Value;

                if (!Guid.TryParse(tenantIdentifier, out Guid parsedTenantIdentifier))
                {
                    return;
                }

                bool isAppUser = await permissionService.CheckAsAppUserTenant(parsedTenantIdentifier);

                if (isAppUser)
                {
                    await permissionService.SetAppUserConnectionString(parsedTenantIdentifier);

                    context.Succeed(requirement);
                }
            }
        }
    }
}
