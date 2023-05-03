using AdvoSecure.Api.Attributes;
using AdvoSecure.Api.Controllers;
using AdvoSecure.Application.Dtos;
using AdvoSecure.Application.Dtos.BillingDtos;
using AdvoSecure.Application.Interfaces.Services;
using AdvoSecure.Common;
using Microsoft.AspNetCore.Mvc;

namespace AdvoSecure.Api.Areas.Application.Controllers
{
    [AppUserDbConfigAction]
    public class CommonController : AdvoControllerBase
    {
        private readonly ICommonService _commonService;

        public CommonController(ICommonService commonService)
        {
            _commonService = commonService;
        }

        [HttpGet("billing-rates")]
        public async Task<IActionResult> GetBillingRates()
        {
            ServiceResult<IEnumerable<BillingRateDto>> serviceResult = await _commonService.GetBillingRatesAsync();

            if (serviceResult.Success)
            {
                return Ok(serviceResult.Result);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpGet("billing-groups")]
        public async Task<IActionResult> GetBillingGroups()
        {
            ServiceResult<IEnumerable<BillingGroupDto>> serviceResult = await _commonService.GetBillingGroupsAsync();

            if (serviceResult.Success)
            {
                return Ok(serviceResult.Result);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpGet("company-legal-statuses")]
        public async Task<IActionResult> GetCompanyLegalStatuses()
        {
            ServiceResult<IEnumerable<CompanyLegalStatusDto>> serviceResult = await _commonService.GetCompanyLegalStatusesAsync();

            if (serviceResult.Success)
            {
                return Ok(serviceResult.Result);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpGet("countries")]
        public async Task<IActionResult> GetCountries()
        {
            ServiceResult<IEnumerable<CountryDto>> serviceResult = await _commonService.GetCountriesAsync();

            if (serviceResult.Success)
            {
                return Ok(serviceResult.Result);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpGet("tasktypes")]
        public async Task<IActionResult> GetTaskTypes()
        {
            ServiceResult<IEnumerable<TaskTypeDto>> serviceResult = await _commonService.GetTaskTypeAsync();

            if (serviceResult.Success)
            {
                return Ok(serviceResult.Result);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
