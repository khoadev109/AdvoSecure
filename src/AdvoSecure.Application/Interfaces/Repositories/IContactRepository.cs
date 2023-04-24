using AdvoSecure.Application.Dtos.ContactDtos;
using AdvoSecure.Domain.Entities;
using AdvoSecure.Domain.Entities.ContactEntities;

namespace AdvoSecure.Application.Interfaces.Repositories
{
    public interface IContactRepository
    {
        Task<IEnumerable<Country>> GetAllCountriesAsync();

        IQueryable<Contact> GetContacts(string searchTerm);

        IQueryable<ContactIdType> GetIdTypes();

        IQueryable<ContactCivilStatus> GetMaritalStatuses();

        Task<Contact> GetById(int id);

        Task<bool> IsExisting(int id);

        Task<Contact> Create(Contact contact, string userEmail);

        Task<Contact> Update(ContactDto contactDto, string userEmail);
    }
}
