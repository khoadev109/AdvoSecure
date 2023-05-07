using AdvoSecure.Common.Persistance;
using AdvoSecure.Domain.Entities.Matters;
using AdvoSecure.Domain.Interfaces.Requests;

namespace AdvoSecure.Domain.Interfaces.Repositories
{
    public interface IMatterRepository : IRepository<Matter>
    {
        Task<Matter> GetByIdAsync(Guid id);

        Task<IEnumerable<Matter>> SearchAsync(MatterSearchRequest request);

        Task<Matter> CreateAsync(Matter matter, string userName);

        Matter Update(Matter matter, string userName);
    }
}
