using AdvoSecure.Application.Dtos;
using AdvoSecure.Application.Interfaces.Services;
using AdvoSecure.Api.Authentication;
using AdvoSecure.Infrastructure.Authorization;
using AdvoSecure.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AdvoSecure.Api.Areas.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly JwtResolver _jwtResolver;
        private readonly RsaResolver _rsaResolver;
        private readonly ITenantService _tenantService;
        private readonly IUserService _userService;

        public AccountController(UserManager<ApplicationUser> userManager, IConfiguration configuration, JwtResolver jwtResolver, RsaResolver rsaResolver, ITenantService tenantService, IUserService userService)
        {
            _userManager = userManager;
            _configuration = configuration;
            _jwtResolver = jwtResolver;
            _rsaResolver = rsaResolver;
            _tenantService = tenantService;
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var plainPassword = _rsaResolver.Decrypt(request.Password);

            await _userService.SetAppUserConnectionString(request.UserName);

            ApplicationUser user = await _userManager.FindByNameAsync(request.UserName); 
            if (user == null)
            {
                throw new UnauthorizedAccessException("User does not exist.");
            }

            bool isValidUser = await _userManager.CheckPasswordAsync(user, plainPassword);
            if (!isValidUser)
            {
                throw new UnauthorizedAccessException("User name or password is invalid.");
            }

            TenantSettingDto tenant = await _tenantService.GetTenantByUserIdentifier(user.UserIdentifier) ?? throw new UnauthorizedAccessException("Invalid tenant.");

            if (!tenant.AdminId.HasValue)
            {
                throw new UnauthorizedAccessException("User is in role of tenant admin.");
            }

            TenantSettingDto tenantAdmin = await _tenantService.GetTenantAdmin(tenant.AdminId.Value);

            var userClaims = new UserClaims
            {
                Id = user.Id,
                Name = user.DisplayName,
                Email = user.Email ?? string.Empty,
                UserIdentifier = user.UserIdentifier.ToString(),
                TenantAdminIdentifier = tenantAdmin.TenantIdentifier.ToString(),
                TenantIdentifier = tenant.TenantIdentifier.ToString()
            };

            string accessToken = _jwtResolver.GenerateAccessToken(userClaims);

            string refreshToken = await StoreAndReturnRefreshToken(user.UserIdentifier, tenant.TenantIdentifier);

            var tokenResponse = new JwtTokenResponse
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                UserIdentifier = user.UserIdentifier.ToString(),
                TenantIdentifier = tenant.TenantIdentifier.ToString(),
            };

            return Ok(tokenResponse);
        }

        [HttpPost("refreshtoken")]
        public async Task<IActionResult> GenerateRefreshToken(RefreshTokenRequest request)
        {
            if (request == null)
            {
                throw new UnauthorizedAccessException("Invalid payload for refresh token.");
            }

            if (!Guid.TryParse(request.UserIdentifier, out Guid parsedUserIdentifier))
            {
                throw new UnauthorizedAccessException("Missing user identifier.");
            }

            if (!Guid.TryParse(request.TenantIdentifier, out Guid parsedTenantIdentifier))
            {
                throw new UnauthorizedAccessException("Missing tenant identifier.");
            }

            RefreshTokenDto refreshTokenDto = await _userService.GetAppRefreshTokenAsync(parsedUserIdentifier, parsedTenantIdentifier);

            if (refreshTokenDto.Token != request.RefreshToken)
            {
                throw new UnauthorizedAccessException("Invalid refresh token.");
            }
            else if (refreshTokenDto.Expires >= DateTime.Now)
            {
                throw new UnauthorizedAccessException("Token expired.");
            }

            TenantUserDto user = await _userService.FindByUserIdentifierAsync(refreshTokenDto.UserIdentifier);

            TenantSettingDto tenant = await _tenantService.GetTenantByUserIdentifier(user.UserIdentifier) ?? throw new UnauthorizedAccessException("Invalid tenant.");

            TenantSettingDto tenantAdmin = await _tenantService.GetTenantById(tenant.AdminId.Value);

            var userClaims = new UserClaims
            {
                Id = user.Id.ToString(),
                Name = user.Name,
                Email = user.Email,
                UserIdentifier = request?.UserIdentifier,
                TenantIdentifier = request?.TenantIdentifier,
                TenantAdminIdentifier = tenantAdmin.TenantIdentifier.ToString()
            };

            string accessToken = _jwtResolver.GenerateAccessToken(userClaims);

            string refreshToken = await StoreAndReturnRefreshToken(parsedUserIdentifier, parsedTenantIdentifier);

            var tokenResponse = new JwtTokenResponse
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                UserIdentifier = request.UserIdentifier,
                TenantIdentifier = request.TenantIdentifier,
            };

            return Ok(tokenResponse);
        }

        [HasPermission(Permission.AsAppUser)]
        [HttpGet("profile")]
        public async Task<IActionResult> GetProfile()
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimConstants.UserId)?.Value ?? throw new UnauthorizedAccessException("User does not exist.");

                var userEmail = User.Claims.FirstOrDefault(x => x.Type == ClaimConstants.UserName)?.Value ?? throw new UnauthorizedAccessException("User does not exist.");

                await _userService.SetAppUserConnectionString(userEmail);

                ApplicationUser user = await _userManager.FindByIdAsync(userId) ?? throw new UnauthorizedAccessException("User does not exist.");

                return Ok(user);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HasPermission(Permission.AsAppUser)]
        [HttpPost("update-profile")]
        public async Task<IActionResult> UpdateProfile(AppUserProfileRequestDto request)
        {
            await _userService.SetAppUserConnectionString(request.Email);

            ApplicationUser user = await _userManager.GetUserAsync(User) ?? throw new UnauthorizedAccessException("User does not exist.");

            ApplicationUser updatedAppUser = await _userService.UpdateAppUserProfile(request);

            if (updatedAppUser == null)
            {
                throw new Exception("Failed to update app user.");
            }

            TenantUserDto updatedTenantUser = await _userService.UpdateTenantUser(request);

            if (updatedTenantUser == null)
            {
                throw new Exception("Failed to update tenant user.");
            }

            return Ok(user);
        }

        [HasPermission(Permission.AsAppUser)]
        [HttpGet("password-reset")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ForgotPasswordRequest request)
        {
            await _userService.SetAppUserConnectionString(request.Email);

            ApplicationUser user = await _userManager.FindByEmailAsync(request.Email) ?? throw new UnauthorizedAccessException("User does not exist.");

            string token = await _userManager.GeneratePasswordResetTokenAsync(user);

            // Update TenantUser password (AdvoSecure.Infrastructure.Persistance.Management.Repositories/UserRepository)

            var response = new ForgotPasswordMessage
            {
                ResetToken = token,
                Email = request.Email,
                ReturnUrl = request.ReturnUrl
            };

            // Send mail
            //await _emailSender.SendEmailAsync(response);

            return Ok(response);
        }

        private async Task<string> StoreAndReturnRefreshToken(Guid userIdentifier, Guid tenantIdentifier)
        {
            var refreshToken = _jwtResolver.GenerateRefreshToken();

            var refreshTokenDto = new RefreshTokenDto
            {
                Token = refreshToken.Token,
                Created = refreshToken.Created,
                Expires = refreshToken.Expires,
                UserIdentifier = userIdentifier,
                TenantIdentifier = tenantIdentifier
            };

            await _userService.SaveTenantRefreshTokenAsync(refreshTokenDto);

            return refreshToken.Token;
        }
    }
}
