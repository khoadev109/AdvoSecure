using AdvoSecure.Api.Attributes;
using AdvoSecure.Api.Controllers;
using AdvoSecure.Application.Dtos.ContactDtos;
using AdvoSecure.Application.Dtos.MatterDtos;
using AdvoSecure.Application.Interfaces.Services;
using AdvoSecure.Infrastructure.Authorization;
using AdvoSecure.Infrastructure.Services;
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

        [HttpGet("types")]
        public async Task<IActionResult> GetMatterTypes()
        {
            IEnumerable<MatterTypeDto> result = await _matterService.GetMatterTypesAsync();

            return Ok(result);
        }

        [HttpGet("areas")]
        public async Task<IActionResult> GetMatterAreas()
        {
            IEnumerable<MatterAreaDto> result = await _matterService.GetMatterAreasAsync();

            return Ok(result);
        }

        [HttpGet("court-city")]
        public async Task<IActionResult> GetCourtSittingInCities()
        {
            IEnumerable<CourtSittingInCityDto> result = await _matterService.GetCourtSittingInCitiesAsync();

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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MatterDto matterRequestDto)
        {
            try
            {
                MatterDto matterDto = await _matterService.CreateMatterAsync(matterRequestDto, CurrentUserName);

                return Ok(matterDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Create matter internal server error: {ex}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] MatterDto matterRequestDto)
        {
            try
            {
                MatterDto matterDto = await _matterService.UpdateMatterAsync(id, matterRequestDto, CurrentUserName);

                return Ok(matterDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Update matter internal server error: {ex}");
            }
        }
    }
}
