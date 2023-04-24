using AdvoSecure.Application.Dtos.ContactDtos;
using AdvoSecure.Application.Interfaces.Repositories;
using AdvoSecure.Application.Interfaces.Services;
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

        public async Task<IEnumerable<ContactDto>> GetContactsAsync(string searchTerm)
        {
            IList<Contact> contacts = await _contactRepository.GetContacts(searchTerm).OrderBy(x => x.DisplayName).ToListAsync();

            IEnumerable<ContactDto> contactDtos = _mapper.Map<IEnumerable<ContactDto>>(contacts);

            return contactDtos;
        }

        public async Task<IEnumerable<ContactDto>> GetCompaniesAsync(string searchTerm)
        {
            IList<Contact> companies = await _contactRepository.GetContacts(searchTerm).Where(c => c.IsOrganization).OrderBy(x => x.DisplayName).ToListAsync();

            IEnumerable<ContactDto> contactDtos = _mapper.Map<IEnumerable<ContactDto>>(companies);

            return contactDtos;
        }

        public async Task<IEnumerable<ContactDto>> GetEmployeesAsync(string searchTerm)
        {
            IList<Contact> employees = await _contactRepository.GetContacts(searchTerm).Where(c => c.IsOurEmployee).OrderBy(x => x.DisplayName).ToListAsync();

            IEnumerable<ContactDto> contactDtos = _mapper.Map<IEnumerable<ContactDto>>(employees);

            return contactDtos;
        }

        public async Task<IEnumerable<ContactDto>> GetPersonsAsync(string searchTerm)
        {
            IList<Contact> persons = await _contactRepository.GetContacts(searchTerm).Where(c => !c.IsOurEmployee).OrderBy(x => x.DisplayName).ToListAsync();

            IEnumerable<ContactDto> contactDtos = _mapper.Map<IEnumerable<ContactDto>>(persons);

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
        
        public async Task<ContactDto> GetContactByIdAsync(int id)
        {
            Contact contact = await _contactRepository.GetById(id);

            ContactDto contactDto = _mapper.Map<ContactDto>(contact);

            return contactDto;
        }

        public async Task<ContactDto> CreateContactAsync(ContactDto contactDto, string userName)
        {
            Contact newContact = _mapper.Map<Contact>(contactDto);

            Contact createdContact = await _contactRepository.Create(newContact, userName);

            ContactDto createdContactDto = _mapper.Map<ContactDto>(createdContact);

            return createdContactDto;
        }

        public async Task<ContactDto> UpdateContactAsync(int id, ContactDto contactDto, string userName)
        {
            contactDto.Id = id;

            Contact updatedContact = await _contactRepository.Update(contactDto, userName);

            ContactDto updatedContactDto = _mapper.Map<ContactDto>(updatedContact);

            return updatedContactDto;
        }
    }
}
