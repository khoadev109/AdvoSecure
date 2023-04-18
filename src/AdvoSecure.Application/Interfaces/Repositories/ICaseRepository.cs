using AdvoSecure.Domain.Entities;

namespace AdvoSecure.Application.Interfaces.Repositories
{
    public interface ICaseRepository
    {
        Task<IEnumerable<Case>> GetAllAsync();
    }
}
