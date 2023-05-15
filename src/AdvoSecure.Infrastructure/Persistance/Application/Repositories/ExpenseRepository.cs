using AdvoSecure.Common.Persistance;
using AdvoSecure.Domain.Entities.Billings;
using AdvoSecure.Domain.Interfaces.Repositories;
using AdvoSecure.Infrastructure.Persistance.App;
using Microsoft.EntityFrameworkCore;

namespace AdvoSecure.Infrastructure.Persistance.Application.Repositories
{
    public class ExpenseRepository : Repository<Expense>, IExpenseRepository
    {
        public ExpenseRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Expense>> GetUnbilledExpensesByMatterIdAsync(Guid matterId, DateTime? start = null,
            DateTime? stop = null)
        {
            List<Expense> expenses = await GetQueryable().Include(x => x.InvoiceExpenses).Include(x => x.Matters)
                .Where(x => x.Matters.Any(y => y.Id == matterId) && x.InvoiceExpenses.All(y => y.ExpenseId != x.Id))
                .Where(x => 
                    (!start.HasValue && !stop.HasValue) ||
                    (start.HasValue && x.Incurred >= start.Value) ||
                    (stop.HasValue && x.Incurred <= stop.Value))
                .ToListAsync();

            return expenses;
        }
    }
}
