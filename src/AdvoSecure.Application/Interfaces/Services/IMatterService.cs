using AdvoSecure.Application.Dtos.MatterDtos;

namespace AdvoSecure.Application.Interfaces.Services
{
    public interface IMatterService
    {
        Task<IEnumerable<MatterTypeDto>> GetMatterTypesAsync();

        Task<IEnumerable<MatterAreaDto>> GetMatterAreasAsync();

        Task<IEnumerable<CourtSittingInCityDto>> GetCourtSittingInCitiesAsync();

        Task<IEnumerable<CourtGeographicalJurisdictionDto>> GetCourtGeographicalJurisdictionsAsync();

        Task<MatterDto> GetMatterAsync(string id);

        Task<IEnumerable<MatterDto>> SearchMattersAsync(MatterSearchRequestDto requestDto);

        Task<MatterDto> CreateMatterAsync(MatterDto matterDto, string userName);

        Task<MatterDto> UpdateMatterAsync(string id, MatterDto matterDto, string userName);
    }
}
