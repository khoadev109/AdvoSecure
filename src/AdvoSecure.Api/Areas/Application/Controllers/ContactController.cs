using AdvoSecure.Api.Attributes;
using AdvoSecure.Api.Controllers;
using AdvoSecure.Application.Dtos;
using AdvoSecure.Application.Dtos.ContactDtos;
using AdvoSecure.Application.Interfaces.Services;
using AdvoSecure.Common;
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
            ServiceResult<ContactDto> serviceResult = await _contactService.GetContactByIdAsync(id);

            if (serviceResult.Success)
            {
                return Ok(serviceResult.Result);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetContacts(string searchTerm)
        {
            ServiceResult<IEnumerable<ContactDto>> serviceResult = await _contactService.GetContactsAsync(searchTerm);

            if (serviceResult.Success)
            {
                return Ok(serviceResult.Result);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpGet("companies")]
        public async Task<IActionResult> GetCompanies(string searchTerm)
        {
            ServiceResult<IEnumerable<ContactDto>> serviceResult = await _contactService.GetCompaniesAsync(searchTerm);

            if (serviceResult.Success)
            {
                return Ok(serviceResult.Result);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpGet("employees")]
        public async Task<IActionResult> GetEmployees(string searchTerm)
        {
            ServiceResult<IEnumerable<ContactDto>> serviceResult = await _contactService.GetEmployeesAsync(searchTerm);

            if (serviceResult.Success)
            {
                return Ok(serviceResult.Result);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpGet("persons")]
        public async Task<IActionResult> GetPersons(string searchTerm)
        {
            ServiceResult<IEnumerable<ContactDto>> serviceResult = await _contactService.GetPersonsAsync(searchTerm);

            if (serviceResult.Success)
            {
                return Ok(serviceResult.Result);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpGet("id-types")]
        public async Task<IActionResult> GetIdTypes()
        {
            ServiceResult<IEnumerable<ContactIdTypeDto>> serviceResult = await _contactService.GetIdTypesAsync();

            if (serviceResult.Success)
            {
                return Ok(serviceResult.Result);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpGet("marital-statuses")]
        public async Task<IActionResult> GetMarialStatuses()
        {
            ServiceResult<IEnumerable<ContactCivilStatusDto>> serviceResult = await _contactService.GetMaritalStatusesAsync();

            if (serviceResult.Success)
            {
                return Ok(serviceResult.Result);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpGet("languages")]
        public async Task<IActionResult> GetLanguages()
        {
            ServiceResult<IEnumerable<LanguageDto>> serviceResult = await _contactService.GetLanguagesAsync();

            if (serviceResult.Success)
            {
                return Ok(serviceResult.Result);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ContactDto contactRequestDto)
        {
            ServiceResult<ContactDto> serviceResult = await _contactService.CreateContactAsync(contactRequestDto, CurrentUserName);

            if (serviceResult.Success)
            {
                return Ok(serviceResult.Result);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ContactDto contactRequestDto)
        {
            ServiceResult<ContactDto> serviceResult = await _contactService.UpdateContactAsync(id, contactRequestDto, CurrentUserName);

            if (serviceResult.Success)
            {
                return Ok(serviceResult.Result);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpGet("contact-titles")]
        public async Task<IActionResult> GetContactTitle()
        {
            ServiceResult<IEnumerable<ContactTitleDTO>> serviceResult = await _contactService.GetContactTitleAsync();

            if (serviceResult.Success)
            {
                return Ok(serviceResult.Result);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
