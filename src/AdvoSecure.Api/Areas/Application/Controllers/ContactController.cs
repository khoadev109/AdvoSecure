using AdvoSecure.Application.Dtos;
using AdvoSecure.Application.Dtos.ContactDtos;
using AdvoSecure.Application.Interfaces.Services;
using AdvoSecure.Infrastructure.Authorization;
using AdvoSecure.Security;
using Microsoft.AspNetCore.Mvc;

namespace AdvoSecure.Api.Areas.Application.Controllers
{
    [HasPermission(Permission.AsAppUser)]
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IUserService _userService;

        public ContactController(IContactService ContactService, IUserService userService)
        {
            _contactService = ContactService;
            _userService = userService;
        }

        [HttpGet("Countries")]
        public async Task<IActionResult> GetAll()
        {
            var userNameClaim = User.Claims.First(x => x.Type == ClaimConstants.UserName)?.Value;

            await _userService.SetAppUserConnectionString(userNameClaim);

            IEnumerable<CountryDto> Countries = await _contactService.GetAllCountriesAsync();

            return Ok(new { Countries });
        }

        [HttpGet("contacts")]
        public async Task<IActionResult> GetContacts(string searchTerm)
        {
            var userNameClaim = User.Claims.First(x => x.Type == ClaimConstants.UserName)?.Value;

            await _userService.SetAppUserConnectionString(userNameClaim);

            IEnumerable<ContactDto> contacts = await _contactService.GetContactsAsync(searchTerm);

            return Ok(contacts);
        }

        [HttpGet("employees")]
        public async Task<IActionResult> GetEmployees(string searchTerm)
        {
            var userNameClaim = User.Claims.First(x => x.Type == ClaimConstants.UserName)?.Value;

            await _userService.SetAppUserConnectionString(userNameClaim);

            IEnumerable<ContactDto> employees = await _contactService.GetEmployeesAsync(searchTerm);

            return Ok(employees);
        }

        [HttpGet("persons")]
        public async Task<IActionResult> GetPersons(string searchTerm)
        {
            var userNameClaim = User.Claims.First(x => x.Type == ClaimConstants.UserName)?.Value;

            await _userService.SetAppUserConnectionString(userNameClaim);

            IEnumerable<ContactDto> persons = await _contactService.GetPersonsAsync(searchTerm);

            return Ok(persons);
        }
    }
}
