using AdvoSecure.Application.Dtos.MatterDtos;
using AdvoSecure.Domain.Entities.Matters;

namespace AdvoSecure.Application.Interfaces.Repositories
{
    public interface IMatterRepository
    {
        IQueryable<MatterType> GetMatterTypes();

        Task<Matter> GetMatterByIdAsync(Guid id);

        IQueryable<MatterArea> GetMatterAreas();

        IQueryable<CourtSittingInCity> GetCourtSittingInCities();

        IQueryable<CourtGeographicalJurisdiction> GetCourtGeographicalJurisdictions();

        IQueryable<Matter> GetMatters();

        Task<Matter> Create(Matter matter, string userName);

        Task<Matter> Update(MatterDto matterDto, string userName);
    }
}
