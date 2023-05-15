using AdvoSecure.Common.Persistance;
using AdvoSecure.Domain.Entities.Billings;
using AdvoSecure.Domain.Interfaces.Repositories;
using AdvoSecure.Infrastructure.Persistance.App;
using Microsoft.EntityFrameworkCore;

namespace AdvoSecure.Infrastructure.Persistance.Application.Repositories
{
    public class FeeRepository : Repository<Fee>, IFeeRepository
    {
        public FeeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Fee>> GetUnbilleFeesByMatterIdAsync(Guid matterId, DateTime? start = null,
            DateTime? stop = null)
        {
            List<Fee> fees = await GetQueryable().Include(x => x.InvoiceFees).Include(x => x.Matters)
                .Where(x => x.Matters.Any(y => y.Id == matterId) && x.InvoiceFees.All(y => y.FeeId != x.Id))
                .Where(x =>
                    (!start.HasValue && !stop.HasValue) ||
                    (start.HasValue && x.Incurred >= start.Value) ||
                    (stop.HasValue && x.Incurred <= stop.Value))
                .ToListAsync();

            return fees;
        }
    }
}
