using AdvoSecure.Application.Dtos;
using AdvoSecure.Application.Dtos.ContactDtos;

namespace AdvoSecure.Application.Interfaces.Services
{
    public interface IContactService
    {
        Task<IEnumerable<CountryDto>> GetAllCountriesAsync();

        Task<IEnumerable<ContactDto>> GetContactsAsync(string searchTerm);

        Task<IEnumerable<ContactDto>> GetEmployeesAsync(string searchTerm);

        Task<IEnumerable<ContactDto>> GetPersonsAsync(string searchTerm);

        Task<IEnumerable<ContactIdTypeDto>> GetIdTypesAsync();

        Task<IEnumerable<ContactCivilStatusDto>> GetMaritalStatusesAsync();

        Task<ContactDto> SaveContactAsync(ContactDto contactDto, string userName);
    }
}
