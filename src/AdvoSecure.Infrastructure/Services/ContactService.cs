using AdvoSecure.Application.Dtos;
using AdvoSecure.Application.Dtos.ContactDtos;
using AdvoSecure.Application.Interfaces.Repositories;
using AdvoSecure.Application.Interfaces.Services;
using AdvoSecure.Domain.Entities;
using AdvoSecure.Domain.Entities.ContactEntities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AdvoSecure.Infrastructure.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public ContactService(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CountryDto>> GetAllCountriesAsync()
        {
            IEnumerable<Country> countries = await _contactRepository.GetAllCountriesAsync();

            IEnumerable<CountryDto> countryDtos = _mapper.Map<IEnumerable<CountryDto>>(countries);

            return countryDtos;
        }

        public async Task<IEnumerable<ContactDto>> GetContactsAsync(string searchTerm)
        {
            IList<Contact> contacts = await _contactRepository.GetContacts(searchTerm).OrderBy(x => x.DisplayName).ToListAsync();

            IEnumerable<ContactDto> contactDtos = _mapper.Map<IEnumerable<ContactDto>>(contacts);

            return contactDtos;
        }

        public async Task<IEnumerable<ContactDto>> GetEmployeesAsync(string searchTerm)
        {
            IList<Contact> contacts = await _contactRepository.GetContacts(searchTerm).Where(c => c.IsOurEmployee).OrderBy(x => x.DisplayName).ToListAsync();

            IEnumerable<ContactDto> contactDtos = _mapper.Map<IEnumerable<ContactDto>>(contacts);

            return contactDtos;
        }

        public async Task<IEnumerable<ContactDto>> GetPersonsAsync(string searchTerm)
        {
            IList<Contact> contacts = await _contactRepository.GetContacts(searchTerm).Where(c => !c.IsOurEmployee).OrderBy(x => x.DisplayName).ToListAsync();

            IEnumerable<ContactDto> contactDtos = _mapper.Map<IEnumerable<ContactDto>>(contacts);

            return contactDtos;
        }

        public async Task<IEnumerable<ContactIdTypeDto>> GetIdTypesAsync()
        {
            IList<ContactIdType> idTypes = await _contactRepository.GetIdTypes().ToListAsync();

            IEnumerable<ContactIdTypeDto> idTypeDtos = _mapper.Map<IEnumerable<ContactIdTypeDto>>(idTypes);

            return idTypeDtos;
        }

        public async Task<IEnumerable<ContactCivilStatusDto>> GetMaritalStatusesAsync()
        {
            IList<ContactCivilStatus> statuses = await _contactRepository.GetMaritalStatuses().ToListAsync();

            IEnumerable<ContactCivilStatusDto> statusDtos = _mapper.Map<IEnumerable<ContactCivilStatusDto>>(statuses);

            return statusDtos;
        }

        public async Task<ContactDto> SaveContactAsync(ContactDto contactDto, string userName)
        {
            bool exist = await _contactRepository.IsExisting(contactDto.Id);

            Contact savingContact = _mapper.Map<Contact>(contactDto);

            Contact savedContact = exist ? await _contactRepository.Update(savingContact) : await _contactRepository.Create(savingContact, userName);

            ContactDto savedContactDto = _mapper.Map<ContactDto>(savedContact);

            return savedContactDto;
        }
    }
}
