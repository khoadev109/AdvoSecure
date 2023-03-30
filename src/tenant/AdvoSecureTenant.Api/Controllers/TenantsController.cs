using AdvoSecureTenant.Core.Services;
using AdvoSecureTenant.Core.Services.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace AdvoSecureTenant.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TenantsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly TenantService _tenantService;
        
        public TenantsController(IConfiguration configuration, TenantService tenantService)
        {
            _configuration = configuration;
            _tenantService = tenantService;
        }

        [Authorize]
        [HttpGet("CheckTenantExist/{azureTenantId}")]
        [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scope")]
        public async Task<CheckExistingTenantResponseDto> CheckTenantExist(string azureTenantId)
        {
            CheckExistingTenantResponseDto result = await _tenantService.CheckTenantExist(azureTenantId);
            return result;
        }

        [Authorize]
        [HttpGet("CheckValidTenant/{azureTenantId}")]
        [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scope")]
        public async Task<bool> CheckValidTenant(string azureTenantId)
        {
            bool valid = await _tenantService.CheckValidTenant(azureTenantId);
            return valid;
        }

        [Authorize]
        [HttpPost("CreateTenant")]
        [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scope")]
        public async Task<TenantDto> CreateTenant(TenantDto newTenant)
        {
            TenantDto tenant = await _tenantService.CreateTenant(newTenant);

            return tenant;
        }

        // Todo: check scope from the api call from tenant app
        [HttpGet("ByTenantId/{azureTenantId}")]
        public async Task<TenantDto> GetByAzureTenantId(string azureTenantId)
        {
            TenantDto tenant = await _tenantService.GetByAzureTenantId(azureTenantId);

            return tenant;
        }
    }
}
