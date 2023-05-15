using AdvoSecure.Application.Dtos;
using AdvoSecure.Application.Dtos.ContactDtos;
using AdvoSecure.Application.Interfaces.Services;
using AdvoSecure.Common;
using AdvoSecure.Domain.Entities;
using AdvoSecure.Domain.Entities.Contacts;
using AdvoSecure.Domain.Interfaces;
using AutoMapper;

namespace AdvoSecure.Application.Services
{
    public class ContactService : ServiceBase, IContactService
    {
        private readonly IMapper _mapper;
        private readonly IAppUnitOfWork _unitOfWork;

        public ContactService(IMapper mapper, IAppUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResult<IEnumerable<ContactDto>>> GetContactsAsync(string searchTerm)
        {
            ServiceResult<IEnumerable<ContactDto>> result = await ExecuteAsync<IEnumerable<ContactDto>>(async () =>
            {
                IEnumerable<Contact> contacts = await _unitOfWork.ContactRepository.GetContactsAsync(searchTerm);

                IEnumerable<ContactDto> contactDtos = _mapper.Map<IEnumerable<ContactDto>>(contacts);

                return new ServiceSuccessResult<IEnumerable<ContactDto>>(contactDtos);
            });

            return result;
        }

        public async Task<ServiceResult<IEnumerable<ContactDto>>> GetCompaniesAsync(string searchTerm)
        {
            ServiceResult<IEnumerable<ContactDto>> result = await ExecuteAsync<IEnumerable<ContactDto>>(async () =>
            {
                IEnumerable<Contact> companies = await _unitOfWork.ContactRepository.GetCompaniesAsync(searchTerm);

                IEnumerable<ContactDto> companyDtos = _mapper.Map<IEnumerable<ContactDto>>(companies);

                return new ServiceSuccessResult<IEnumerable<ContactDto>>(companyDtos);
            });

            return result;
        }

        public async Task<ServiceResult<IEnumerable<ContactDto>>> GetEmployeesAsync(string searchTerm)
        {
            ServiceResult<IEnumerable<ContactDto>> result = await ExecuteAsync<IEnumerable<ContactDto>>(async () =>
            {
                IEnumerable<Contact> employees = await _unitOfWork.ContactRepository.GetEmployeesAsync(searchTerm);

                IEnumerable<ContactDto> employeeDtos = _mapper.Map<IEnumerable<ContactDto>>(employees);

                return new ServiceSuccessResult<IEnumerable<ContactDto>>(employeeDtos);
            });

            return result;
        }

        public async Task<ServiceResult<IEnumerable<ContactDto>>> GetPersonsAsync(string searchTerm)
        {
            ServiceResult<IEnumerable<ContactDto>> result = await ExecuteAsync<IEnumerable<ContactDto>>(async () =>
            {
                IEnumerable<Contact> persons = await _unitOfWork.ContactRepository.GetPersonsAsync(searchTerm);

                IEnumerable<ContactDto> personDtos = _mapper.Map<IEnumerable<ContactDto>>(persons);

                return new ServiceSuccessResult<IEnumerable<ContactDto>>(personDtos);
            });

            return result;
        }

        public async Task<ServiceResult<IEnumerable<ContactIdTypeDto>>> GetIdTypesAsync()
        {
            ServiceResult<IEnumerable<ContactIdTypeDto>> result = await ExecuteAsync<IEnumerable<ContactIdTypeDto>>(async () =>
            {
                IEnumerable<ContactIdType> idTypes = await _unitOfWork.ContactIdTypeRepository.GetAllAsync();

                IEnumerable<ContactIdTypeDto> idTypeDtos = _mapper.Map<IEnumerable<ContactIdTypeDto>>(idTypes);

                return new ServiceSuccessResult<IEnumerable<ContactIdTypeDto>>(idTypeDtos);
            });

            return result;
        }

        public async Task<ServiceResult<IEnumerable<ContactCivilStatusDto>>> GetMaritalStatusesAsync()
        {
            ServiceResult<IEnumerable<ContactCivilStatusDto>> result = await ExecuteAsync<IEnumerable<ContactCivilStatusDto>>(async () =>
            {
                IEnumerable<ContactCivilStatus> statuses = await _unitOfWork.ContactCivilStatusRepository.GetAllAsync();

                IEnumerable<ContactCivilStatusDto> statusDtos = _mapper.Map<IEnumerable<ContactCivilStatusDto>>(statuses);

                return new ServiceSuccessResult<IEnumerable<ContactCivilStatusDto>>(statusDtos);
            });

            return result;
        }
        
        public async Task<ServiceResult<ContactDto>> GetContactByIdAsync(int id)
        {
            ServiceResult<ContactDto> result = await ExecuteAsync<ContactDto>(async () =>
            {
                Contact contact = await _unitOfWork.ContactRepository.GetAsync(x => x.Id == id);

                ContactDto contactDto = _mapper.Map<ContactDto>(contact);

                return new ServiceSuccessResult<ContactDto>(contactDto);
            });

            return result;
        }

        public async Task<ServiceResult<IEnumerable<LanguageDto>>> GetLanguagesAsync()
        {
            ServiceResult<IEnumerable<LanguageDto>> result = await ExecuteAsync<IEnumerable<LanguageDto>>(async () =>
            {
                IEnumerable<Language> languages = await _unitOfWork.LanguageRepository.GetAllAsync();

                IEnumerable<LanguageDto> languageDtos = _mapper.Map<IEnumerable<LanguageDto>>(languages);

                return new ServiceSuccessResult<IEnumerable<LanguageDto>>(languageDtos);
            });

            return result;
        }

        public async Task<ServiceResult<ContactDto>> CreateContactAsync(ContactDto contactDto, string userName)
        {
            ServiceResult<ContactDto> result = await ExecuteAsync<ContactDto>(async () =>
            {
                Contact newContact = _mapper.Map<Contact>(contactDto);

                Contact createdContact = await _unitOfWork.ContactRepository.CreateAsync(newContact, userName);

                await _unitOfWork.CommitAsync();

                ContactDto createdContactDto = _mapper.Map<ContactDto>(createdContact);

                return new ServiceSuccessResult<ContactDto>(createdContactDto);
            });

            return result;
        }

        public async Task<ServiceResult<ContactDto>> UpdateContactAsync(int id, ContactDto contactDto, string userName)
        {
            ServiceResult<ContactDto> result = await ExecuteAsync<ContactDto>(async () =>
            {
                contactDto.Id = id;

                Contact existingContact = await _unitOfWork.ContactRepository.GetAsync(x => x.Id == id);

                existingContact.CreatedBy = userName;
                existingContact = _mapper.Map(contactDto, existingContact);

                Contact updatedContact = _unitOfWork.ContactRepository.Update(existingContact, userName);

                await _unitOfWork.CommitAsync();

                ContactDto updatedContactDto = _mapper.Map<ContactDto>(updatedContact);

                return new ServiceSuccessResult<ContactDto>(updatedContactDto);
            });

            return result;
        }
    }
}
