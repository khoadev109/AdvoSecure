using AdvoSecure.Api.Attributes;
using AdvoSecure.Application.Dtos.ContactDtos;
using AdvoSecure.Application.Interfaces.Services;
using AdvoSecure.Infrastructure.Authorization;
using AdvoSecure.Infrastructure.Helpers;
using AdvoSecure.Security;
using Microsoft.AspNetCore.Mvc;

namespace AdvoSecure.Api.Areas.Application.Controllers
{
    [HasPermission(Permission.AsAppUser)]
    [Route("api/[controller]")]
    [AppUserConfigDb]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet("contacts")]
        public async Task<IActionResult> GetContacts(string searchTerm)
        {
            IEnumerable<ContactDto> contacts = await _contactService.GetContactsAsync(searchTerm);

            return Ok(contacts);
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

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] ContactDto contact)
        {
            try
            {
                var userNameClaim = User.Claims.First(x => x.Type == ClaimConstants.UserName)?.Value;

                ContactDto contactDto = await _contactService.SaveContactAsync(contact, userNameClaim);

                return Ok(contactDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}
