using AdvoSecure.Api.Attributes;
using AdvoSecure.Application.Dtos;
using AdvoSecure.Application.Dtos.BillingDtos;
using AdvoSecure.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdvoSecure.Api.Areas.Application.Controllers
{
    [Route("api/[controller]")]
    [AppUserConfigDb]
    [ApiController]
    public class CommonController : ControllerBase
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

        [HttpGet("countries")]
        public async Task<IActionResult> GetCountries()
        {
            IEnumerable<CountryDto> countries = await _commonService.GetCountriesAsync();

            return Ok(countries);
        }
    }
}
