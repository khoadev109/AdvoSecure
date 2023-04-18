using AdvoSecure.Application.Dtos;
using AdvoSecure.Application.Interfaces.Services;
using AdvoSecure.Infrastructure.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdvoSecure.Api.Areas.Management.Controllers
{
    [Route("api/[controller]")]
    [HasPermission(Permission.AsTenantAdmin)]
    [ApiController]
    public class TenantController : ControllerBase
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
