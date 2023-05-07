using AdvoSecure.Common.Persistance;
using AdvoSecure.Domain.Entities.Contacts;

namespace AdvoSecure.Domain.Interfaces.Repositories
{
    public interface IContactRepository : IRepository<Contact>
    {
        Task<IEnumerable<Contact>> GetContactsAsync(string searchTerm);

        Task<IEnumerable<Contact>> GetCompaniesAsync(string searchTerm);

        Task<IEnumerable<Contact>> GetEmployeesAsync(string searchTerm);

        Task<IEnumerable<Contact>> GetPersonsAsync(string searchTerm);

        Task<Contact> CreateAsync(Contact contact, string userName);

        Contact Update(Contact contact, string userName);
    }
}
