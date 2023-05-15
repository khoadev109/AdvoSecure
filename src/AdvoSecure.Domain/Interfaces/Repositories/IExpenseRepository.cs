using AdvoSecure.Common.Persistance;
using AdvoSecure.Domain.Entities.Billings;

namespace AdvoSecure.Domain.Interfaces.Repositories
{
    public interface IExpenseRepository : IRepository<Expense>
    {
        Task<IEnumerable<Expense>> GetUnbilledExpensesByMatterIdAsync(Guid matterId, DateTime? start = null,
            DateTime? stop = null);
    }
}
