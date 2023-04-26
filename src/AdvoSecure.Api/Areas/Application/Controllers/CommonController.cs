using AdvoSecure.Api.Attributes;
using AdvoSecure.Api.Controllers;
using AdvoSecure.Application.Dtos;
using AdvoSecure.Application.Dtos.BillingDtos;
using AdvoSecure.Application.Dtos.ContactDtos;
using AdvoSecure.Application.Interfaces.Services;
using AdvoSecure.Infrastructure.Services;
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

        [HttpGet("languages")]
        public async Task<IActionResult> GetLanguages()
        {
            IEnumerable<LanguageDto> languages = await _commonService.GetLanguagesAsync();

            return Ok(languages);
        }

        [HttpGet("tasktypes")]
        public async Task<IActionResult> GetTaskTypes()
        {
            IEnumerable<TaskTypeDto> tasktypes = await _commonService.GetTaskTypeAsync();

            return Ok(tasktypes);
        }
    }
}
