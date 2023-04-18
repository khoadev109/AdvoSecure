using AdvoSecure.Application.Dtos;

namespace AdvoSecure.Application.Interfaces.Services
{
    public interface ICaseService
    {
        Task<IEnumerable<CaseDto>> GetAllAsync();
    }
}
