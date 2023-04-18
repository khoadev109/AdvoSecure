using AdvoSecure.Application.Dtos;
using AdvoSecure.Application.Dtos.ContactDtos;

namespace AdvoSecure.Application.Interfaces.Services
{
    public interface IContactService
    {
        Task<IEnumerable<CountryDto>> GetAllCountriesAsync();

        Task<IEnumerable<ContactDto>> GetAllEmployeesAsync();
    }
}
