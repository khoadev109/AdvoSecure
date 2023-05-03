using AdvoSecure.Application.Dtos;
using AdvoSecure.Application.Dtos.BillingDtos;
using AdvoSecure.Common;

namespace AdvoSecure.Application.Interfaces.Services
{
    public interface ICommonService
    {
        Task<ServiceResult<IEnumerable<BillingRateDto>>> GetBillingRatesAsync();

        Task<ServiceResult<IEnumerable<BillingGroupDto>>> GetBillingGroupsAsync();

        Task<ServiceResult<IEnumerable<CompanyLegalStatusDto>>> GetCompanyLegalStatusesAsync();

        Task<ServiceResult<IEnumerable<CountryDto>>> GetCountriesAsync();

        Task<ServiceResult<IEnumerable<TaskTypeDto>>> GetTaskTypeAsync();
    }
}
