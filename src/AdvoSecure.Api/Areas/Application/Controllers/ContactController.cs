using AdvoSecure.Application.Dtos;
using AdvoSecure.Application.Dtos.ContactDtos;
using AdvoSecure.Application.Interfaces.Services;
using AdvoSecure.Infrastructure.Authorization;
using AdvoSecure.Security;
using Microsoft.AspNetCore.Mvc;

namespace AdvoSecure.Api.Areas.Application.Controllers
{
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

        [HasPermission(Permission.AsAppUser)]
        [HttpGet("Countries")]
        public async Task<IActionResult> GetAll()
        {
            var userNameClaim = User.Claims.First(x => x.Type == ClaimConstants.UserName)?.Value;

            await _userService.SetAppUserConnectionString(userNameClaim);

            IEnumerable<CountryDto> Countries = await _contactService.GetAllCountriesAsync();

            return Ok(new { Countries });
        }

        [HasPermission(Permission.AsAppUser)]
        [HttpGet("employees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var userNameClaim = User.Claims.First(x => x.Type == ClaimConstants.UserName)?.Value;

            await _userService.SetAppUserConnectionString(userNameClaim);

            IEnumerable<ContactDto> employees = await _contactService.GetAllEmployeesAsync();

            return Ok(employees);
        }
    }
}
