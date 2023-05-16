using AdvoSecure.Application.Dtos;
using AdvoSecure.Application.Dtos.ContactDtos;
using AdvoSecure.Common;

namespace AdvoSecure.Application.Interfaces.Services
{
    public interface IContactService
    {
        Task<ServiceResult<IEnumerable<ContactDto>>> GetContactsAsync(string searchTerm);

        Task<ServiceResult<IEnumerable<ContactDto>>> GetCompaniesAsync(string searchTerm);

        Task<ServiceResult<IEnumerable<ContactDto>>> GetEmployeesAsync(string searchTerm);

        Task<ServiceResult<IEnumerable<ContactDto>>> GetPersonsAsync(string searchTerm);

        Task<ServiceResult<IEnumerable<ContactIdTypeDto>>> GetIdTypesAsync();

        Task<ServiceResult<IEnumerable<ContactCivilStatusDto>>> GetMaritalStatusesAsync();

        Task<ServiceResult<ContactDto>> GetContactByIdAsync(int id);

        Task<ServiceResult<IEnumerable<LanguageDto>>> GetLanguagesAsync();
        
        Task<ServiceResult<IEnumerable<ContactTitleDTO>>> GetContactTitleAsync();

        Task<ServiceResult<ContactDto>> CreateContactAsync(ContactDto contactDto, string userName);

        Task<ServiceResult<ContactDto>> CreateEmployee(ContactDto contactDto, string Code);

        Task<ServiceResult<ContactDto>> UpdateContactAsync(int id, ContactDto contactDto, string userName);
    }
}
