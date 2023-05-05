using AdvoSecure.Application.Interfaces.Repositories;
using AdvoSecure.Common.Persistance;
using AdvoSecure.Domain.Entities.Tasks;
using AdvoSecure.Infrastructure.Persistance.App;
using Microsoft.EntityFrameworkCore;

namespace AdvoSecure.Infrastructure.Persistance.Application.Repositories
{
    public class TaskRepository : Repository<InnerTask>, ITaskRepository
    {
        public TaskRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<InnerTask>> GetTasksByMatterIdAsync(Guid matterId, bool? active)
        {
            var query = GetQueryable().Where(x => !x.ParentId.HasValue && x.Matters.Any(y => y.Id == matterId) && (!active.HasValue || active.Value));

            IEnumerable<InnerTask> tasks = await query.ToListAsync();

            return tasks;
        }
    }
}
