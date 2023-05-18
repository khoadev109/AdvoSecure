using AdvoSecure.Security;
using Microsoft.AspNetCore.Mvc;

namespace AdvoSecure.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvoControllerBase : ControllerBase
    {
        public string CurrentUserId => User.Claims.First(x => x.Type == ClaimConstants.UserId)?.Value ?? string.Empty;

        public string CurrentUserName => User.Claims.First(x => x.Type == ClaimConstants.UserName)?.Value ?? string.Empty;

        public string CurrentUserCode => User.Claims.First(x => x.Type == ClaimConstants.UserCode)?.Value ?? string.Empty;

        public string CurrentUserDisplayName => User.Claims.First(x => x.Type == ClaimConstants.DisplayName)?.Value ?? string.Empty;

        public string CurrentUserIdentifier => User.Claims.First(x => x.Type == ClaimConstants.UserIdentifier)?.Value ?? string.Empty;

        public string CurrentTenantIdentifier => User.Claims.First(x => x.Type == ClaimConstants.TenantIdentifier)?.Value ?? string.Empty;

        public string CurrentTenantAdminIdentifier => User.Claims.First(x => x.Type == ClaimConstants.TenantAdminIdentifier)?.Value ?? string.Empty;
    }
}
