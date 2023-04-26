using AdvoSecure.Application.Interfaces.Repositories;
using AdvoSecure.Domain.Entities.Matters;
using AdvoSecure.Infrastructure.Persistance.App;
using Microsoft.EntityFrameworkCore;

namespace AdvoSecure.Infrastructure.Persistance.Application.Repositories
{
    public class MatterRepository : IMatterRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public MatterRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<MatterArea> GetMatterAreas()
        {
            return _dbContext.MatterAreas.OrderBy(x => x.AreaCode);
        }

        public IQueryable<CourtGeographicalJurisdiction> GetCourtGeographicalJurisdictions()
        {
            return _dbContext.CourtGeographicalJurisdictions.OrderBy(x => x.Title);
        }

        public IQueryable<Matter> GetMatters()
        {
            return _dbContext.Matters;
        }
    }
}
