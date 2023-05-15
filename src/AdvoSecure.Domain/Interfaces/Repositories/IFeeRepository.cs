using AdvoSecure.Common.Persistance;
using AdvoSecure.Domain.Entities.Billings;

namespace AdvoSecure.Domain.Interfaces.Repositories
{
    public interface IFeeRepository : IRepository<Fee>
    {
        Task<IEnumerable<Fee>> GetUnbilleFeesByMatterIdAsync(Guid matterId, DateTime? start = null,
            DateTime? stop = null);
    }
}
