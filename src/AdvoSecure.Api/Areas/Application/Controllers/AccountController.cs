using AdvoSecure.Api.Attributes;
using AdvoSecure.Api.Authentication;
using AdvoSecure.Api.Controllers;
using AdvoSecure.Application.Dtos;
using AdvoSecure.Application.Interfaces.Services;
using AdvoSecure.Common;
using AdvoSecure.Infrastructure.Authorization;
using AdvoSecure.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AdvoSecure.Api.Areas.Application.Controllers
{
    public class AccountController : AdvoControllerBase
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

            ApplicationUser user = await _userManager.FindByNameAsync(request.UserName) ?? throw new UnauthorizedAccessException("User does not exist.");

            bool isValidUser = await _userManager.CheckPasswordAsync(user, plainPassword);
            if (!isValidUser)
            {
                throw new UnauthorizedAccessException("User name or password is invalid.");
            }

            ServiceResult<TenantSettingDto> tenantResult = await _tenantService.GetTenantByUserIdentifierAsync(user.UserIdentifier);
            if (!tenantResult.Success)
            {
                throw new UnauthorizedAccessException("Invalid tenant.");
            }

            TenantSettingDto tenant = tenantResult.Result;

            if (!tenant.AdminId.HasValue)
            {
                throw new UnauthorizedAccessException("User is in role of tenant admin.");
            }

            ServiceResult<TenantSettingDto> tenantAdminResult = await _tenantService.GetTenantAdminAsync(tenant.AdminId.Value);

            TenantSettingDto tenantAdmin = tenantAdminResult.Result;

            var userClaims = new UserClaims
            {
                Id = user.Id,
                Name = user.DisplayName,
                Email = user.Email ?? string.Empty,
                UserIdentifier = user.UserIdentifier.ToString(),
                TenantAdminIdentifier = tenantAdmin?.TenantIdentifier.ToString() ?? string.Empty,
                TenantIdentifier = tenant.TenantIdentifier.ToString(),
                Code = user.Code
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
        public async Task<IActionResult> GenerateRefreshToken(AuthRefreshTokenRequest request)
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

            ServiceResult<TenantUserDto> userResult = await _userService.FindByUserIdentifierAsync(refreshTokenDto.UserIdentifier);

            if (!userResult.Success)
            {
                throw new UnauthorizedAccessException("User does not exist.");
            }

            TenantUserDto user = userResult.Result;

            ServiceResult<TenantSettingDto> tenantResult = await _tenantService.GetTenantByUserIdentifierAsync(user.UserIdentifier);

            if (!tenantResult.Success)
            {
                throw new UnauthorizedAccessException("Invalid tenant.");
            }

            TenantSettingDto tenant = tenantResult.Result;

            ServiceResult < TenantSettingDto> tenantAdminResult = await _tenantService.GetTenantByIdAsync(tenant.AdminId.Value);

            TenantSettingDto tenantAdmin = tenantAdminResult.Result;

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
        [AppUserDbConfigAction]
        public async Task<IActionResult> GetProfile()
        {
            try
            {
                var userId = CurrentUserId ?? throw new UnauthorizedAccessException("User does not exist.");

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
        [AppUserDbConfigAction]
        public async Task<IActionResult> UpdateProfile(AppUserProfileRequestDto request)
        {
            ApplicationUser user = await _userManager.GetUserAsync(User) ?? throw new UnauthorizedAccessException("User does not exist.");

            ServiceResult<ApplicationUser> updatedAppUserResult = await _userService.UpdateAppUserProfile(request);

            if (!updatedAppUserResult.Success)
            {
                throw new Exception("Failed to update app user.");
            }

            ServiceResult<TenantUserDto> updatedTenantUserResult = await _userService.UpdateTenantUser(request);

            if (!updatedTenantUserResult.Success)
            {
                throw new Exception("Failed to update tenant user.");
            }

            return Ok(user);
        }

        [HasPermission(Permission.AsAppUser)]
        [HttpGet("password-reset")]
        [AppUserDbConfigAction]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ForgotPasswordRequest request)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(request.Email) ?? throw new UnauthorizedAccessException("User does not exist.");

            string token = await _userManager.GeneratePasswordResetTokenAsync(user);

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

            await _userService.SaveAppRefreshTokenAsync(refreshTokenDto);

            return refreshToken.Token;
        }
    }
}
