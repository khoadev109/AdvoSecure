using AdvoSecure.Api.Controllers;
using AdvoSecure.Application.Dtos;
using AdvoSecure.Application.Interfaces.Services;
using AdvoSecure.Common;
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
        public async Task<IActionResult> GetAllTenants()
        {
            ServiceResult<IEnumerable<TenantSettingDto>> serviceResult = await _tenantService.GetAllTenantsAsync();

            if (serviceResult.Success)
            {
                return Ok(serviceResult.Result);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
