using AdvoSecure.Application.Interfaces.Repositories;
using AdvoSecure.Domain.Entities;
using AdvoSecure.Domain.Entities.ContactEntities;
using Microsoft.EntityFrameworkCore;

namespace AdvoSecure.Infrastructure.Persistance.App.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ContactRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Country>> GetAllCountriesAsync()
        {
            IEnumerable<Country> Countries = await _dbContext.Countries.ToListAsync<Country>();
            return Countries;
        }

        public IQueryable<Contact> GetContacts(string searchTerm)
        {
            IQueryable<Contact> contacts = _dbContext.Contacts;

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                contacts = contacts.Where(c => !string.IsNullOrWhiteSpace(searchTerm) && c.DisplayName.Contains(searchTerm));
            }

            return contacts;
        }
    }
}
