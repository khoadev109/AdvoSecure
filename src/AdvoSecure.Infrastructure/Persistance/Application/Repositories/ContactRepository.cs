using AdvoSecure.Application.Dtos.ContactDtos;
using AdvoSecure.Application.Interfaces.Repositories;
using AdvoSecure.Domain.Entities;
using AdvoSecure.Domain.Entities.ContactEntities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AdvoSecure.Infrastructure.Persistance.App.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public ContactRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
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

        public IQueryable<ContactIdType> GetIdTypes()
        {
            return _dbContext.ContactIdTypes;
        }

        public IQueryable<ContactCivilStatus> GetMaritalStatuses()
        {
            return _dbContext.ContactCivilStatuses;
        }

        public Task<bool> IsExisting(int id)
        {
            return _dbContext.Contacts.AnyAsync(c => c.Id == id);
        }

        public async Task<Contact> Create(Contact contact, string userEmail)
        {
            try
            {
                contact.CreatedBy = userEmail;

                EntityEntry<Contact> result = await _dbContext.Contacts.AddAsync(contact);

                await _dbContext.SaveChangesAsync();

                Contact createdContact = result.Entity;

                return createdContact;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Contact> Update(Contact contact)
        {
            EntityEntry<Contact> result = _dbContext.Update<Contact>(contact);

            await _dbContext.SaveChangesAsync();

            Contact updatedContact = result.Entity;

            return updatedContact;
        }
    }
}
