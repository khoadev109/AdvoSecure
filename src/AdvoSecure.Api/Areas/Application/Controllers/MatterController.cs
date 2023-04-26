using AdvoSecure.Api.Attributes;
using AdvoSecure.Api.Controllers;
using AdvoSecure.Application.Dtos.MatterDtos;
using AdvoSecure.Application.Interfaces.Services;
using AdvoSecure.Infrastructure.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdvoSecure.Api.Areas.Application.Controllers
{
    [HasPermission(Permission.AsAppUser)]
    [AppUserDbConfigAction]
    public class MatterController : AdvoControllerBase
    {
        private readonly IMatterService _matterService;

        public MatterController(IMatterService matterService)
        {
            _matterService = matterService;
        }

        [HttpGet("areas")]
        public async Task<IActionResult> GetMatterAreas()
        {
            IEnumerable<MatterAreaDto> result = await _matterService.GetMatterAreasAsync();

            return Ok(result);
        }

        [HttpGet("court-geo")]
        public async Task<IActionResult> GetCourtGeographicalJurisdictions()
        {
            IEnumerable<CourtGeographicalJurisdictionDto> result = await _matterService.GetCourtGeographicalJurisdictionsAsync();

            return Ok(result);
        }

        [HttpPost("search")]
        public async Task<IActionResult> SearchMatters([FromBody] MatterSearchRequestDto request)
        {
            IEnumerable<MatterDto> result = await _matterService.SearchMattersAsync(request);

            return Ok(result);
        }
    }
}
