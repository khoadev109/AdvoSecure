using AdvoSecure.Application.Dtos;
using AdvoSecure.Common.Logging;
using AdvoSecure.Common.Persistance;
using AdvoSecure.Domain.Exceptions;
using AdvoSecure.Infrastructure.Persistance;
using AdvoSecure.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Net.Http;
using System.Security.Claims;

namespace AdvoSecure.Api
{
    public class AdvoJwtBearerEvents : JwtBearerEvents
    {
        private readonly ILogger _logger;

        public AdvoJwtBearerEvents(ILogger logger)
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

        public async override Task TokenValidated(TokenValidatedContext context)
        {
            ClaimsPrincipal principal = context.Principal;
            var issuerValue = principal.GetIssuerValue();

            Claim tenantIdClaimn = principal.Identities.First().Claims.FirstOrDefault(x => x.Type == AzureADClaimTypes.TenantId);

            string azureTenantId = tenantIdClaimn.Value;

            bool isAuthenticated = principal.Identity.IsAuthenticated;

            if (!isAuthenticated)
            {
                _logger.TokenValidationFailed(principal.GetObjectIdentifierValue(), issuerValue);
                throw new SecurityTokenValidationException();
            }

            if (azureTenantId == "f34b813a-5d56-48d0-811b-96b3de505340")
            {
                _logger.TokenValidationFailed(principal.GetObjectIdentifierValue(), issuerValue);
                throw new SecurityTokenValidationException("Current tenant is Admin Tenant");
            }

            var configuration = context.HttpContext.RequestServices.GetService<IConfiguration>();
            var cacheProvider = context.HttpContext.RequestServices.GetService<CacheProvider>();
            var dbContext = context.HttpContext.RequestServices.GetService<ApplicationDbContext>();
            var httpClientFactory = context.HttpContext.RequestServices.GetService<IHttpClientFactory>();

            string tenantDbConnectionStringCacheKey = $"cache-db-{azureTenantId}";

            string cachedConnectionString = cacheProvider.Get<string>(tenantDbConnectionStringCacheKey);

            if (string.IsNullOrWhiteSpace(cachedConnectionString))
            {
                try
                {
                    var httpClient = httpClientFactory.CreateClient("TenantApi");

                    var getByTenantIdApiUrl = $"{configuration["Tenant:TenantApiUrl"]}/{configuration["Tenant:ByTenantId"]}/{azureTenantId}";

                    HttpResponseMessage response = await httpClient.GetAsync(getByTenantIdApiUrl);

                    response.EnsureSuccessStatusCode();

                    var contentStream = await response.Content.ReadAsStreamAsync();

                    using var streamReader = new StreamReader(contentStream);
                    using var jsonReader = new JsonTextReader(streamReader);

                    JsonSerializer serializer = new();

                    var tenantFromTenantBase = serializer.Deserialize<TenantDto>(jsonReader) ?? throw new NotFoundException("Tenant is not configured yet from tenant base.");

                    dbContext.Database.SetConnectionString(tenantFromTenantBase.ConnectionString);

                    cacheProvider.Set<string>(tenantDbConnectionStringCacheKey, tenantFromTenantBase.ConnectionString);
                }
                catch (Exception ex)
                {
                }
            }
            else
            {
                dbContext.Database.SetConnectionString(cachedConnectionString);
            }

            if (dbContext.Database.IsNpgsql())
            {
                await dbContext.Database.MigrateAsync();
            }

            _logger.TokenValidationSucceeded(principal.GetObjectIdentifierValue(), issuerValue);
        }
    }
}
