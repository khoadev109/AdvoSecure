using AdvoSecure.Application.Dtos.MatterDtos;
using AdvoSecure.Domain.Entities.Matters;

namespace AdvoSecure.Application.Interfaces.Repositories
{
    public interface IMatterRepository
    {
        IQueryable<MatterType> GetMatterTypes();

        IQueryable<MatterArea> GetMatterAreas();

        IQueryable<CourtSittingInCity> GetCourtSittingInCities();

        IQueryable<CourtGeographicalJurisdiction> GetCourtGeographicalJurisdictions();

        IQueryable<Matter> GetMatters();

        Task<Matter> Create(Matter matter, string userEmail);

        Task<Matter> Update(MatterDto matterDto, string userEmail);
    }
}
