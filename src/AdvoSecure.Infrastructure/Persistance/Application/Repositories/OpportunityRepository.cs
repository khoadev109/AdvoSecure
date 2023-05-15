using AdvoSecure.Common.Persistance;
using AdvoSecure.Domain.Entities.Opportunities;
using AdvoSecure.Domain.Interfaces.Repositories;
using AdvoSecure.Infrastructure.Persistance.App;
using Microsoft.EntityFrameworkCore;

namespace AdvoSecure.Infrastructure.Persistance.Application.Repositories
{
    public class OpportunityRepository : Repository<Opportunity>, IOpportunityRepository
    {
        public OpportunityRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Opportunity>> GetByMatterIdAsync(Guid matterId)
        {
            IEnumerable<Opportunity> opportunities = await GetQueryable()
                .Include(x => x.Lead)
                .ThenInclude(x => x.Fee).ThenInclude(x => x.To)
                .Include(x => x.Lead)
                .ThenInclude(x => x.Source).ThenInclude(x => x.Contact)
                .Include(x => x.Lead)
                .ThenInclude(x => x.Status)
                .Include(x => x.Account)
                .Include(x => x.Matter)
                .Where(x => x.MatterId == matterId)
                .ToListAsync();

            return opportunities;
        }
    }
}
