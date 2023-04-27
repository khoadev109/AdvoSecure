using AdvoSecure.Api.Attributes;
using AdvoSecure.Api.Controllers;
using AdvoSecure.Application.Dtos;
using AdvoSecure.Application.Dtos.BillingDtos;
using AdvoSecure.Application.Interfaces.Services;
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
            IEnumerable<BillingRateDto> billingRates = await _commonService.GetBillingRatesAsync();

            return Ok(billingRates);
        }

        [HttpGet("billing-groups")]
        public async Task<IActionResult> GetBillingGroups()
        {
            IEnumerable<BillingGroupDto> billingGroups = await _commonService.GetBillingGroupsAsync();

            return Ok(billingGroups);
        }

        [HttpGet("company-legal-statuses")]
        public async Task<IActionResult> GetCompanyLegalStatuses()
        {
            IEnumerable<CompanyLegalStatusDto> legalStatuses = await _commonService.GetCompanyLegalStatusesAsync();

            return Ok(legalStatuses);
        }

        [HttpGet("countries")]
        public async Task<IActionResult> GetCountries()
        {
            IEnumerable<CountryDto> countries = await _commonService.GetCountriesAsync();

            return Ok(countries);
        }

        [HttpGet("tasktypes")]
        public async Task<IActionResult> GetTaskTypes()
        {
            IEnumerable<TaskTypeDto> tasktypes = await _commonService.GetTaskTypeAsync();

            return Ok(tasktypes);
        }
    }
}
