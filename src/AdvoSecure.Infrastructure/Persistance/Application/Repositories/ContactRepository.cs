using AdvoSecure.Domain.Interfaces.Repositories;
using AdvoSecure.Common.Persistance;
using AdvoSecure.Domain.Entities.Contacts;
using Microsoft.EntityFrameworkCore;

namespace AdvoSecure.Infrastructure.Persistance.App.Repositories
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        public ContactRepository(ApplicationDbContext dbContext) : base (dbContext)
        {
        }

        public async Task<IEnumerable<Contact>> GetContactsAsync(string searchTerm)
        {
            IQueryable<Contact> query = GetContactsQueryBySearchTerm(searchTerm);

            IEnumerable < Contact > contacts = await query.ToListAsync();

            return contacts;
        }

        public async Task<IEnumerable<Contact>> GetCompaniesAsync(string searchTerm)
        {
            IQueryable<Contact> query = GetContactsQueryBySearchTerm(searchTerm);

            query = query.Where(c => c.IsOrganization);

            IEnumerable<Contact> contacts = await query.ToListAsync();

            return contacts;
        }

        public async Task<IEnumerable<Contact>> GetEmployeesAsync(string searchTerm)
        {
            IQueryable<Contact> query = GetContactsQueryBySearchTerm(searchTerm);

            query = query.Where(c => c.IsOurEmployee);

            IEnumerable<Contact> contacts = await query.ToListAsync();

            return contacts;
        }

        public async Task<IEnumerable<Contact>> GetPersonsAsync(string searchTerm)
        {
            IQueryable<Contact> query = GetContactsQueryBySearchTerm(searchTerm);

            query = query.Where(c => !c.IsOrganization && !c.IsOurEmployee);

            IEnumerable<Contact> contacts = await query.ToListAsync();

            return contacts;
        }

        public async Task<Contact> CreateAsync(Contact contact, string userName)
        {
            contact.CreatedBy = userName;
            
            Contact result = await AddAsync(contact);

            return result;
        }

        public Contact Update(Contact contact, string userName)
        {
            contact.ModifiedBy = userName;

            Contact result = Update(contact);

            return result;
        }

        private IQueryable<Contact> GetContactsQueryBySearchTerm(string searchTerm)
        {
            IQueryable<Contact> query = GetQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(c => !string.IsNullOrWhiteSpace(searchTerm) && c.DisplayName.Contains(searchTerm));
            }

            return query;
        }
    }
}
