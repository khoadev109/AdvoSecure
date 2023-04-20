﻿using AdvoSecure.Domain.Entities;
using AdvoSecure.Domain.Entities.ContactEntities;

namespace AdvoSecure.Application.Interfaces.Repositories
{
    public interface IContactRepository
    {
        Task<IEnumerable<Country>> GetAllCountriesAsync();

        IQueryable<Contact> GetContacts(string searchTerm);

        IQueryable<ContactIdType> GetIdTypes();

        IQueryable<ContactCivilStatus> GetMaritalStatuses();
    }
}
