using AdvoSecure.Application.Dtos;
using AdvoSecure.Application.Interfaces.Services;
using AdvoSecure.Api.Authentication;
using AdvoSecure.Infrastructure.Authorization;
using AdvoSecure.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AdvoSecure.Api.Areas.Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantAccountController : ControllerBase
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

            TenantUserDto user = await _userService.FindByEmailAsync(request.UserName) ?? throw new UnauthorizedAccessException("User does not exist.");

            bool isValidUser = await _userService.CheckPasswordAsync(user.Email, plainPassword);

            if (!isValidUser)
            {
                throw new UnauthorizedAccessException("User name or password is invalid.");
            }

            TenantSettingDto tenant = await _tenantService.GetTenantAdminByUserIdentifier(user.UserIdentifier) ?? throw new UnauthorizedAccessException("Invalid tenant or user is not in role of tenant admin.");

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

            TenantUserDto user = await _userService.FindByUserIdentifierAsync(refreshTokenDto.UserIdentifier);

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
            var tenantAdminIdentifierClaim = User.Claims.First(x => x.Type == ClaimConstants.TenantAdminIdentifier)?.Value;

            if (!Guid.TryParse(tenantAdminIdentifierClaim, out Guid tenantAdminIdentifier))
            {
                throw new UnauthorizedAccessException("Missing tenant identifier.");
            }

            request.TenantAdminIdentifier = tenantAdminIdentifier;

            TenantUserDto userExists = await _userService.FindByEmailAsync(request.Email);
            if (userExists != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new RegisterResponse { Success = false, Message = "User already exists!" });
            }

            TenantUserDto result = await _userService.RegisterUserAsync(request);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new RegisterResponse { Success = false, Message = "User creation failed! Please check user details and try again." });
            }

            return Ok(new RegisterResponse { Success = true, Message = "User created successfully!" });
        }

        [HasPermission(Permission.AsTenantAdmin)]
        [HttpGet("all-users")]
        public async Task<IActionResult> GetAllUsers()
        {
            IEnumerable<TenantUserDto> users = await _userService.GetAllUsersAsync();

            return Ok(users);
        }

        [HasPermission(Permission.AsTenantAdmin)]
        [HttpGet("profile/{userIdentifier}")]
        public async Task<IActionResult> GetProfile(string userIdentifier)
        {
            if (!Guid.TryParse(userIdentifier, out Guid parsedUserIdentifier))
            {
                throw new UnauthorizedAccessException("Missing user identifier.");
            }

            TenantUserDto user = await _userService.FindByUserIdentifierAsync(parsedUserIdentifier);

            return Ok(user);
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
