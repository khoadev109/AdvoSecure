using AdvoSecure.Application.Dtos.MatterDtos;
using AdvoSecure.Common.Persistance;
using AdvoSecure.Domain.Entities.Matters;

namespace AdvoSecure.Application.Interfaces.Repositories
{
    public interface IMatterRepository : IRepository<Matter>
    {
        Task<Matter> GetByIdAsync(Guid id);

        Task<IEnumerable<Matter>> SearchAsync(MatterSearchRequestDto request);

        Task<Matter> CreateAsync(Matter matter, string userName);

        Matter Update(Matter matter, string userName);
    }
}
