using Microsoft.AspNetCore.Authentication.JwtBearer;
using AdvoSecure.Common.Logging;

namespace AdvoSecureTenant.Api
{
    public class TenantJwtBearerEvents : JwtBearerEvents
    {
        private readonly ILogger _logger;

        public TenantJwtBearerEvents(ILogger logger)
        {
            _logger = logger;
        }

        public override Task AuthenticationFailed(AuthenticationFailedContext context)
        {
            _logger.AuthenticationFailed(context.Exception);
            return base.AuthenticationFailed(context);
        }

        public override Task MessageReceived(MessageReceivedContext context)
        {
            _logger.TokenReceived();
            return base.MessageReceived(context);
        }

        public override Task TokenValidated(TokenValidatedContext context)
        {
            return base.TokenValidated(context);
        }
    }
}
