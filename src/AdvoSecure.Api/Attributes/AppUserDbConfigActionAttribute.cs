using AdvoSecure.Application.Interfaces.Services;
using AdvoSecure.Security;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AdvoSecure.Api.Attributes
{
    public class AppUserDbConfigActionAttribute : ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var claims = context.HttpContext.User.Claims;
            var userNameClaim = claims.First(x => x.Type == ClaimConstants.UserName)?.Value;
            var tenantIdentifier = claims.First(x => x.Type == ClaimConstants.TenantIdentifier)?.Value;

            if (string.IsNullOrWhiteSpace(tenantIdentifier))
            {
                await Task.CompletedTask;
            }

            IUserService userService = context.HttpContext.RequestServices.GetService<IUserService>();

            await userService.SetAppUserConnectionString(userNameClaim);


            await base.OnActionExecutionAsync(context, next);
        }
    }
}
