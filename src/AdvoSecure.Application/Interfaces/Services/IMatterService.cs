using AdvoSecure.Application.Dtos.MatterDtos;
using AdvoSecure.Common;

namespace AdvoSecure.Application.Interfaces.Services
{
    public interface IMatterService
    {
        Task<ServiceResult<IEnumerable<MatterTypeDto>>> GetMatterTypesAsync();

        Task<ServiceResult<IEnumerable<MatterAreaDto>>> GetMatterAreasAsync();

        Task<ServiceResult<IEnumerable<CourtSittingInCityDto>>> GetCourtSittingInCitiesAsync();

        Task<ServiceResult<IEnumerable<CourtGeographicalJurisdictionDto>>> GetCourtGeographicalJurisdictionsAsync();

        Task<ServiceResult<MatterDto>> GetMatterAsync(string id);

        Task<ServiceResult<IEnumerable<MatterDto>>> SearchMattersAsync(MatterSearchRequestDto requestDto);

        Task<ServiceResult<MatterDto>> CreateMatterAsync(MatterDto matterDto, string userName);

        Task<ServiceResult<MatterDto>> UpdateMatterAsync(string id, MatterDto matterDto, string userName);
    }
}
