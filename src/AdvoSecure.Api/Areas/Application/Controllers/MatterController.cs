using AdvoSecure.Api.Attributes;
using AdvoSecure.Api.Controllers;
using AdvoSecure.Application.Dtos.MatterDtos;
using AdvoSecure.Application.Dtos.Notes;
using AdvoSecure.Application.Dtos.OpportunityDtos;
using AdvoSecure.Application.Interfaces.Services;
using AdvoSecure.Common;
using AdvoSecure.Infrastructure.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdvoSecure.Api.Areas.Application.Controllers
{
    [HasPermission(Permission.AsAppUser)]
    [AppUserDbConfigAction]
    public class MatterController : AdvoControllerBase
    {
        private readonly IMatterService _matterService;
        private readonly INoteService _noteService;
        private readonly IOpportunityService _opportunityService;

        public MatterController(IMatterService matterService, INoteService noteService, IOpportunityService opportunityService)
        {
            _matterService = matterService;
            _noteService = noteService;
            _opportunityService = opportunityService;
        }

        [HttpGet("types")]
        public async Task<IActionResult> GetMatterTypes()
        {
            ServiceResult<IEnumerable<MatterTypeDto>> serviceResult = await _matterService.GetMatterTypesAsync();

            if (serviceResult.Success)
            {
                return Ok(serviceResult.Result);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpGet("areas")]
        public async Task<IActionResult> GetMatterAreas()
        {
            ServiceResult<IEnumerable<MatterAreaDto>> serviceResult = await _matterService.GetMatterAreasAsync();

            if (serviceResult.Success)
            {
                return Ok(serviceResult.Result);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpGet("court-city")]
        public async Task<IActionResult> GetCourtSittingInCities()
        {
            ServiceResult<IEnumerable<CourtSittingInCityDto>> serviceResult = await _matterService.GetCourtSittingInCitiesAsync();

            if (serviceResult.Success)
            {
                return Ok(serviceResult.Result);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpGet("court-geo")]
        public async Task<IActionResult> GetCourtGeoJurisdictions()
        {
            ServiceResult<IEnumerable<CourtGeoJurisdictionDto>> serviceResult = await _matterService.GetCourtGeoJurisdictionsAsync();

            if (serviceResult.Success)
            {
                return Ok(serviceResult.Result);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpGet("{id}/notes")]
        public async Task<IActionResult> GetMatterNotes(string id)
        {
            ServiceResult<IEnumerable<NoteDto>> serviceResult = await _noteService.GetNotesByMatterIdAsync(id);

            if (serviceResult.Success)
            {
                return Ok(serviceResult.Result);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpGet("{id}/opportunities")]
        public async Task<IActionResult> GetMatterOpportunities(string id)
        {
            ServiceResult<IEnumerable<OpportunityDto>> serviceResult = await _opportunityService.GetOpportunitiesByMatterIdAsync(id);

            if (serviceResult.Success)
            {
                return Ok(serviceResult.Result);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPost("search")]
        public async Task<IActionResult> SearchMatters([FromBody] MatterSearchRequestDto request)
        {
            ServiceResult<IEnumerable<MatterDto>> serviceResult = await _matterService.SearchMattersAsync(request);

            if (serviceResult.Success)
            {
                return Ok(serviceResult.Result);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            ServiceResult<MatterDto> serviceResult = await _matterService.GetMatterAsync(id);

            if (serviceResult.Success)
            {
                return Ok(serviceResult.Result);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MatterDto matterRequestDto)
        {
            ServiceResult<MatterDto> serviceResult = await _matterService.CreateMatterAsync(matterRequestDto, CurrentUserName);

            if (serviceResult.Success)
            {
                return Ok(serviceResult.Result);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] MatterDto matterRequestDto)
        {
            ServiceResult<MatterDto> serviceResult = await _matterService.UpdateMatterAsync(id, matterRequestDto, CurrentUserName);

            if (serviceResult.Success)
            {
                return Ok(serviceResult.Result);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
