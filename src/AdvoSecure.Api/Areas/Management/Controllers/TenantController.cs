using AdvoSecure.Api.Controllers;
using AdvoSecure.Application.Dtos;
using AdvoSecure.Application.Interfaces.Services;
using AdvoSecure.Infrastructure.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdvoSecure.Api.Areas.Management.Controllers
{
    [HasPermission(Permission.AsTenantAdmin)]
    public class TenantController : AdvoControllerBase
    {
        private readonly ITenantService _tenantService;

        public TenantController(ITenantService tenantService)
        {
            _tenantService = tenantService;
        }

        [HttpGet]
        public IActionResult GetAllTenants()
        {
            IEnumerable<TenantSettingDto> tenants = _tenantService.GetAllTenants();

            return Ok(tenants);
        }
    }
}
