using AdvoSecure.Common.Persistance;
using AdvoSecure.Domain.Entities.Tasks;

namespace AdvoSecure.Domain.Interfaces.Repositories
{
    public interface ITaskRepository : IRepository<InnerTask>
    {
        Task<IEnumerable<InnerTask>> GetTasksByMatterIdAsync(Guid matterId, bool? active);
    }
}
