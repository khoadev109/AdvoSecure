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

        public IQueryable<Contact> GetAllEmployees()
        {
            IQueryable<Contact> contacts = _dbContext.Contacts.Where(c => c.IsOurEmployee).OrderBy(c => c.DisplayName).AsQueryable();

            return contacts;
        }
    }
}
