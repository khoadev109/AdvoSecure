using AdvoSecure.Application.Dtos;
using AdvoSecure.Application.Interfaces.Services;
using AdvoSecure.Infrastructure.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdvoSecure.Api.Areas.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaseController : ControllerBase
    {
        private readonly ICaseService _CaseService;

        public CaseController(ICaseService CaseService)
        {
            _CaseService = CaseService;
        }

        [HasPermission(Permission.AsAppUser)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<CaseDto> Cases = await _CaseService.GetAllAsync();

            return Ok(new { Cases });
        }
    }
}
