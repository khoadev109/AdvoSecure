using AdvoSecure.Application.Dtos.ContactDtos;
using AdvoSecure.Domain.Entities;
using AdvoSecure.Domain.Entities.Language;
using AdvoSecure.Domain.Entities.Contacts;
using AdvoSecure.Domain.Entities.Tasks;

namespace AdvoSecure.Application.Interfaces.Repositories
{
    public interface IContactRepository
    {
        Task<IEnumerable<Country>> GetAllCountriesAsync();
        Task<IEnumerable<Language>> GetLanguagesAsync();
        Task<IEnumerable<TaskType>> GetTaskType();

        IQueryable<Contact> GetContacts(string searchTerm);

        IQueryable<ContactIdType> GetIdTypes();

        IQueryable<ContactCivilStatus> GetMaritalStatuses();

        Task<Contact> GetById(int id);

        Task<bool> IsExisting(int id);

        Task<Contact> Create(Contact contact, string userEmail);

        Task<Contact> Update(ContactDto contactDto, string userEmail);

        IQueryable<Language> GetLanguages();


    }
}
