using AdvoSecure.Application.Dtos.BillingDtos;
using AdvoSecure.Application.Dtos.MatterDtos;
using AdvoSecure.Application.Dtos.Timing;
using AdvoSecure.Common;

namespace AdvoSecure.Application.Interfaces.Services
{
    public interface IMatterService
    {
        Task<ServiceResult<IEnumerable<MatterTypeDto>>> GetMatterTypesAsync();

        Task<ServiceResult<IEnumerable<MatterAreaDto>>> GetMatterAreasAsync();

        Task<ServiceResult<IEnumerable<CourtSittingInCityDto>>> GetCourtSittingInCitiesAsync();

        Task<ServiceResult<IEnumerable<CourtGeoJurisdictionDto>>> GetCourtGeoJurisdictionsAsync();

        Task<ServiceResult<MatterDto>> GetMatterAsync(string id);

        Task<ServiceResult<IEnumerable<InvoiceExpenseDto>>> GetExpensesByMatterIdAsync(string id);

        Task<ServiceResult<IEnumerable<ExpenseDto>>> GetUnbilledExpensesByMatterIdAsync(string id);

        Task<ServiceResult<IEnumerable<InvoiceFeeDto>>> GetBilledFeesByMatterIdAsync(string id);

        Task<ServiceResult<IEnumerable<FeeDto>>> GetUnbilledFeesByMatterIdAsync(string id);

        Task<ServiceResult<IEnumerable<TimeDto>>> GetTimesByMatterIdAsync(string id);

        Task<ServiceResult<IEnumerable<MatterDto>>> SearchMattersAsync(MatterSearchRequestDto requestDto);

        Task<ServiceResult<MatterDto>> CreateMatterAsync(MatterDto matterDto, string userName);

        Task<ServiceResult<MatterDto>> UpdateMatterAsync(string id, MatterDto matterDto, string userName);
    }
}
