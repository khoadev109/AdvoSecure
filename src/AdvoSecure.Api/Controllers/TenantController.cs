using AdvoSecure.Application.Dtos;
using AdvoSecure.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace AdvoSecure.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scope")]
    public class TenantController : ControllerBase
    {
        private readonly ITenantService _tenantService;

        public TenantController(ITenantService tenantService)
        {
            _tenantService = tenantService;
        }

        [HttpGet]
        public async Task<TenantDto> Index()
        {
            TenantDto tenantDto = await _tenantService.GetTenant();
            return tenantDto;
        }
    }
}
