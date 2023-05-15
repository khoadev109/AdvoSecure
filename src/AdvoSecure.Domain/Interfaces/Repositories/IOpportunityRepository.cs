using AdvoSecure.Common.Persistance;
using AdvoSecure.Domain.Entities.Opportunities;
using AdvoSecure.Domain.Interfaces.Requests;

namespace AdvoSecure.Domain.Interfaces.Repositories
{
    public interface IOpportunityRepository : IRepository<Opportunity>
    {
        Task<IEnumerable<Opportunity>> GetByMatterIdAsync(Guid MatterId);
    }
}

