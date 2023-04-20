using AdvoSecure.Application.Dtos;
using AdvoSecure.Application.Dtos.BillingDtos;
using AdvoSecure.Application.Interfaces.Services;
using AdvoSecure.Infrastructure.Services;
using AdvoSecure.Security;
using Microsoft.AspNetCore.Mvc;

namespace AdvoSecure.Api.Areas.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly ICommonService _commonService;
        private readonly IUserService _userService;

        public CommonController(ICommonService commonService, IUserService userService)
        {
            _commonService = commonService;
            _userService = userService;
        }

        [HttpGet("billing-rates")]
        public async Task<IActionResult> GetBillingRates()
        {
            var userNameClaim = User.Claims.First(x => x.Type == ClaimConstants.UserName)?.Value;

            await _userService.SetAppUserConnectionString(userNameClaim);

            IEnumerable<BillingRateDto> billingRates = await _commonService.GetBillingRatesAsync();

            return Ok(billingRates);
        }

        [HttpGet("countries")]
        public async Task<IActionResult> GetCountries()
        {
            var userNameClaim = User.Claims.First(x => x.Type == ClaimConstants.UserName)?.Value;

            await _userService.SetAppUserConnectionString(userNameClaim);

            IEnumerable<CountryDto> countries = await _commonService.GetCountriesAsync();

            return Ok(countries);
        }
    }
}
