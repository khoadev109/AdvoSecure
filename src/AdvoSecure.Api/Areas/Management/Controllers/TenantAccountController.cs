using AdvoSecure.Api.Authentication;
using AdvoSecure.Api.Controllers;
using AdvoSecure.Application.Dtos;
using AdvoSecure.Application.Interfaces.Services;
using AdvoSecure.Common;
using AdvoSecure.Infrastructure.Authorization;
using AdvoSecure.Security;
using Microsoft.AspNetCore.Mvc;

namespace AdvoSecure.Api.Areas.Management.Controllers
{
    public class TenantAccountController : AdvoControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly JwtResolver _jwtResolver;
        private readonly RsaResolver _rsaResolver;
        private readonly ITenantService _tenantService;
        private readonly IUserService _userService;

        public TenantAccountController(IConfiguration configuration, JwtResolver jwtResolver, RsaResolver rsaResolver, ITenantService tenantService, IUserService userService)
        {
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

            ServiceResult<TenantUserDto> userResult = await _userService.FindByEmailAsync(request.UserName);
            if (!userResult.Success)
            {
                throw new UnauthorizedAccessException("User does not exist.");
            }

            TenantUserDto user = userResult.Result;

            ServiceResult<bool> validUserResult = await _userService.CheckPasswordAsync(user.Email, plainPassword);
            if (!validUserResult.Success)
            {
                throw new UnauthorizedAccessException("User name or password is invalid.");
            }

            ServiceResult<TenantSettingDto> tenantResult = await _tenantService.GetTenantAdminByUserIdentifierAsync(user.UserIdentifier);
            if (!tenantResult.Success)
            {
                throw new UnauthorizedAccessException("Invalid tenant or user is not in role of tenant admin.");
            }

            TenantSettingDto tenant = tenantResult.Result;

            var userClaims = new UserClaims
            {
                Id = user.Id.ToString(),
                Name = user.Name,
                Email = user.Email,
                UserIdentifier = user.UserIdentifier.ToString(),
                TenantAdminIdentifier = tenant.TenantIdentifier.ToString()
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

            RefreshTokenDto refreshTokenDto = await _userService.GetTenantRefreshTokenAsync(parsedUserIdentifier, parsedTenantIdentifier);

            if (refreshTokenDto.Token != request.RefreshToken)
            {
                throw new UnauthorizedAccessException("Invalid refresh token.");
            }
            else if (refreshTokenDto.Expires >= DateTime.Now)
            {
                throw new UnauthorizedAccessException("Token expired.");
            }

            ServiceResult<TenantUserDto> userResult = await _userService.FindByUserIdentifierAsync(refreshTokenDto.UserIdentifier);

            TenantUserDto user = userResult.Result;

            var userClaims = new UserClaims
            {
                Id = user.Id.ToString(),
                Name = user.Name,
                Email = user.Email,
                UserIdentifier = request?.UserIdentifier,
                TenantAdminIdentifier = request?.TenantIdentifier
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

        [HasPermission(Permission.AsTenantAdmin)]
        [HttpPost("register-user")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterRequest request)
        {
            if (!Guid.TryParse(CurrentTenantAdminIdentifier, out Guid tenantAdminIdentifier))
            {
                throw new UnauthorizedAccessException("Missing tenant identifier.");
            }

            request.TenantAdminIdentifier = tenantAdminIdentifier;

            ServiceResult<TenantUserDto> userResult = await _userService.FindByEmailAsync(request.Email);

            if (!userResult.Success)
            {
                return StatusCode(StatusCodes.Status200OK, new RegisterResponse { Success = false, Message = "User already exists!" });
            }

            ServiceResult < TenantUserDto> registerResult = await _tenantService.RegisterUserAsync(request, CurrentUserName);
            if (!registerResult.Success)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new RegisterResponse { Success = false, Message = "User creation failed! Please check user details and try again." });
            }

            return Ok(new RegisterResponse { Success = true, Message = "User created successfully!" });
        }

        [HasPermission(Permission.AsTenantAdmin)]
        [HttpGet("all-users")]
        public async Task<IActionResult> GetAllUsers()
        {
            ServiceResult<IEnumerable<TenantUserDto>> usersResult = await _userService.GetAllUsersAsync();

            if (usersResult.Success)
            {
                return Ok(usersResult.Result);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HasPermission(Permission.AsTenantAdmin)]
        [HttpGet("profile/{userIdentifier}")]
        public async Task<IActionResult> GetProfile(string userIdentifier)
        {
            if (!Guid.TryParse(userIdentifier, out Guid parsedUserIdentifier))
            {
                throw new UnauthorizedAccessException("Missing user identifier.");
            }

            ServiceResult<TenantUserDto> userResult = await _userService.FindByUserIdentifierAsync(parsedUserIdentifier);

            if (userResult.Success)
            {
                return Ok(userResult.Result);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
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
