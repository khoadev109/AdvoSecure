using AdvoSecure.Application.Dtos.MatterDtos;

namespace AdvoSecure.Application.Interfaces.Services
{
    public interface IMatterService
    {
        Task<IEnumerable<MatterAreaDto>> GetMatterAreasAsync();

        Task<IEnumerable<CourtGeographicalJurisdictionDto>> GetCourtGeographicalJurisdictionsAsync();

        Task<IEnumerable<MatterDto>> SearchMattersAsync(MatterSearchRequestDto requestDto);
    }
}
