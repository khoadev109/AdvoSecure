using AdvoSecure.Domain.Entities.Matters;

namespace AdvoSecure.Application.Interfaces.Repositories
{
    public interface IMatterRepository
    {
        IQueryable<MatterArea> GetMatterAreas();

        IQueryable<CourtGeographicalJurisdiction> GetCourtGeographicalJurisdictions();

        IQueryable<Matter> GetMatters();
    }
}
