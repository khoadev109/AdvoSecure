using AdvoSecure.Application.Dtos;
using AdvoSecure.Application.Dtos.BillingDtos;

namespace AdvoSecure.Application.Interfaces.Services
{
    public interface ICommonService
    {
        Task<IEnumerable<BillingRateDto>> GetBillingRatesAsync();

        Task<IEnumerable<CountryDto>> GetCountriesAsync();
    }
}
