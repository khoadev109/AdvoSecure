using AdvoSecure.Application.Dtos;
using AdvoSecure.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace AdvoSecure.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scope")]
    public class AccountController : ControllerBase
    {
        private readonly ITenantService _tenantService;
        private readonly IUserService _userService;

        public AccountController(ITenantService tenantService, IUserService userService)
        {
            _tenantService = tenantService;
            _userService = userService;
        }

        [HttpPost("user")]
        public async Task<bool> CreateUser(OrgInitializationRequestDto orgRequestDto)
        {
            try
            {
                UserDto newUserDto = new()
                {
                    AzureIdentityId = orgRequestDto.AzureIdentityId,
                    AzureEmail = orgRequestDto.AzureEmail,
                    AzureTenantId = orgRequestDto.AzureTenantId,
                    CreatedBy = orgRequestDto.AzureIdentityId,
                    CreatedDateTime = DateTime.Now
                };

                await _userService.CreateUser(newUserDto);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost("user-org")]
        public async Task<bool> CreateUserOrganization(OrgInitializationRequestDto orgRequestDto)
        {
            try
            {
                UserDto newUserDto = new()
                {
                    AzureIdentityId = orgRequestDto.AzureIdentityId,
                    AzureEmail = orgRequestDto.AzureEmail,
                    AzureTenantId = orgRequestDto.AzureTenantId,
                    CreatedBy = orgRequestDto.AzureIdentityId,
                    CreatedDateTime = DateTime.Now
                };

                await _userService.CreateUser(newUserDto);

                await _tenantService.CreateTenantFromTenantBase(orgRequestDto);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
