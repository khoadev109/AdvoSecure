using AdvoSecure.Api.Attributes;
using AdvoSecure.Api.Controllers;
using AdvoSecure.Application.Dtos.ContactDtos;
using AdvoSecure.Application.Interfaces.Services;
using AdvoSecure.Infrastructure.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdvoSecure.Api.Areas.Application.Controllers
{
    [HasPermission(Permission.AsAppUser)]
    [AppUserDbConfigAction]
    public class ContactController : AdvoControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            ContactDto contact = await _contactService.GetContactByIdAsync(id);

            return Ok(contact);
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetContacts(string searchTerm)
        {
            IEnumerable<ContactDto> contacts = await _contactService.GetContactsAsync(searchTerm);

            return Ok(contacts);
        }

        [HttpGet("companies")]
        public async Task<IActionResult> GetCompanies(string searchTerm)
        {
            IEnumerable<ContactDto> employees = await _contactService.GetCompaniesAsync(searchTerm);

            return Ok(employees);
        }

        [HttpGet("employees")]
        public async Task<IActionResult> GetEmployees(string searchTerm)
        {
            IEnumerable<ContactDto> employees = await _contactService.GetEmployeesAsync(searchTerm);

            return Ok(employees);
        }

        [HttpGet("persons")]
        public async Task<IActionResult> GetPersons(string searchTerm)
        {
            IEnumerable<ContactDto> persons = await _contactService.GetPersonsAsync(searchTerm);

            return Ok(persons);
        }

        [HttpGet("id-types")]
        public async Task<IActionResult> GetIdTypes()
        {
            IEnumerable<ContactIdTypeDto> idTypes = await _contactService.GetIdTypesAsync();

            return Ok(idTypes);
        }

        [HttpGet("marital-statuses")]
        public async Task<IActionResult> GetMarialStatuses()
        {
            IEnumerable<ContactCivilStatusDto> maritalStatuses = await _contactService.GetMaritalStatusesAsync();

            return Ok(maritalStatuses);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ContactDto contact)
        {
            try
            {
                ContactDto contactDto = await _contactService.CreateContactAsync(contact, CurrentUserName);

                return Ok(contactDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Create contact internal server error: {ex}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ContactDto contact)
        {
            try
            {
                ContactDto contactDto = await _contactService.UpdateContactAsync(id, contact, CurrentUserName);

                return Ok(contactDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Update contact internal server error: {ex}");
            }
        }
    }
}
