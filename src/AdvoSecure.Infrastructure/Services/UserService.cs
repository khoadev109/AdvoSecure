using AdvoSecure.Application.Dtos;
using AdvoSecure.Application.Interfaces.Repositories;
using AdvoSecure.Application.Interfaces.Services;
using AdvoSecure.Common.Persistance;
using AdvoSecure.Domain.Entities;
using AdvoSecure.Infrastructure.Persistance;
using AdvoSecure.Infrastructure.Persistance.App;
using AdvoSecure.Infrastructure.Persistance.Tenant;
using AdvoSecure.Security;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace AdvoSecure.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _appDbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserRepository _userRepository;

        private readonly ITenantRepository _tenantRepository;
        private readonly IDirectoryRepository _directoryRepository;
        private readonly IRefreshTokenRepositoryFactory _refreshTokenRepositoryFactory;
        private readonly IMapper _mapper;

        public UserService(ApplicationDbContext appDbContext, UserManager<ApplicationUser> userManager, IUserRepository userRepository, ITenantRepository tenantRepository, IDirectoryRepository directoryRepository, IRefreshTokenRepositoryFactory refreshTokenRepositoryFactory, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _userManager = userManager;
            _userRepository = userRepository;
            _tenantRepository = tenantRepository;
            _directoryRepository = directoryRepository;
            _refreshTokenRepositoryFactory = refreshTokenRepositoryFactory;
            _mapper = mapper;
        }

        public async Task<bool> CheckPasswordAsync(string userName, string password)
        {
            bool existed = await _userRepository.CheckPasswordAsync(userName, password);
            return existed;
        }

        public async Task<TenantUserDto> FindByEmailAsync(string email)
        {
            TenantUser user = await _userRepository.FindByEmailAsync(email);

            TenantUserDto userDto = _mapper.Map<TenantUserDto>(user);

            return userDto;
        }

        public async Task<TenantUserDto> FindByUserIdentifierAsync(Guid userIdentifier)
        {
            TenantUser user = await _userRepository.FindByUserIdentifierAsync(userIdentifier);

            TenantUserDto userDto = _mapper.Map<TenantUserDto>(user);

            return userDto;
        }

        public async Task<TenantUserDto> RegisterUserAsync(RegisterRequest request)
        {
            try
            {
                if (request.SetAsAdmin.GetValueOrDefault())
                {
                    TenantUser newAdminUser = await _userRepository.CreateAsync(request);

                    TenantSetting tenantAdmin = await _tenantRepository.GetAdminAsync(request.TenantAdminIdentifier);

                    TenantDirectory mappedDirectory = await _directoryRepository.CreateAsync(tenantAdmin, newAdminUser);

                    if (mappedDirectory == null)
                    {
                        return null;
                    }

                    TenantUserDto newAdminUserDto = _mapper.Map<TenantUserDto>(newAdminUser);

                    return newAdminUserDto;
                }

                Guid.TryParse(request.TenantIdentifier, out Guid parsedTenantIdentifier);

                TenantSetting tenant = await _tenantRepository.GetAsync(parsedTenantIdentifier);

                if (tenant == null)
                {
                    tenant = await _tenantRepository.CreateAsync(request.TenantAdminIdentifier);
                }

                TenantUser newUser = await _userRepository.CreateAsync(request);

                await _appDbContext.SetConnectionStringAndRunMigration(tenant.ConnectionString);

                if (tenant != null && newUser != null)
                {
                    TenantDirectory mappedDirectory = await _directoryRepository.CreateAsync(tenant, newUser);

                    if (mappedDirectory == null)
                    {
                        return null;
                    }

                    try
                    {
                        var appUser = new ApplicationUser
                        {
                            UserName = request.Email,
                            DisplayName = request.DisplayName,
                            Email = request.Email,
                            FirstName = request.FirstName,
                            LastName = request.LastName,
                            UserIdentifier = newUser.UserIdentifier
                        };

                        IdentityResult result = await _userManager.CreateAsync(appUser, request.Password);

                        if (result.Succeeded)
                        {
                            TenantUserDto userDto = _mapper.Map<TenantUserDto>(newUser);

                            return userDto;
                        }
                    }
                    catch (Exception ex)
                    {

                        throw;
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ApplicationUser> UpdateAppUserProfile(AppUserProfileRequestDto request)
        {
            ApplicationUser user = await _userManager.GetUserAsync(request.User);

            if (user == null)
            {
                return null;
            }

            user.DisplayName = request.DisplayName;
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;
            user.UserName = request.Email;

            IdentityResult result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return user;
            }

            return null;
        }

        public async Task<TenantUserDto> UpdateTenantUser(AppUserProfileRequestDto request)
        {
            if (Guid.TryParse(request.UserIdentifier, out Guid parsedUserIdentifier))
            {
                TenantUser user = await _userRepository.FindByUserIdentifierAsync(parsedUserIdentifier);

                TenantUser updatedUser = await _userRepository.SaveAsync(user);

                TenantUserDto updatedUserDto = _mapper.Map<TenantUserDto>(updatedUser);

                return updatedUserDto;
            }

            return null;
        }

        public async Task<IEnumerable<TenantUserDto>> GetAllUsersAsync()
        {
            IEnumerable<TenantUser> users = (await _userRepository.GetAllAsync()).AsEnumerable();

            IEnumerable<TenantUserDto> userDtos = _mapper.Map<IEnumerable<TenantUserDto>>(users);

            return userDtos;
        }

        public async Task SaveTenantRefreshTokenAsync(RefreshTokenDto dto)
        {
            IRefreshTokenRepository refreshTokenRepository = _refreshTokenRepositoryFactory.GetInstance(typeof(MgmtDbContext));

            await refreshTokenRepository.DeleteAsync(dto);

            await refreshTokenRepository.SaveAsync(dto);
        }

        public async Task<RefreshTokenDto> GetTenantRefreshTokenAsync(Guid userIdentifier, Guid tenantIdentifier)
        {
            IRefreshTokenRepository refreshTokenRepository = _refreshTokenRepositoryFactory.GetInstance(typeof(MgmtDbContext));

            Domain.Entities.RefreshToken refreshToken = await refreshTokenRepository.GetByUserAndTenantIdentifierAsync(userIdentifier, tenantIdentifier);

            RefreshTokenDto dto = _mapper.Map<RefreshTokenDto>(refreshToken);

            return dto;
        }

        public async Task<RefreshTokenDto> GetAppRefreshTokenAsync(Guid userIdentifier, Guid tenantIdentifier)
        {
            IRefreshTokenRepository refreshTokenRepository = _refreshTokenRepositoryFactory.GetInstance(typeof(ApplicationDbContext));

            Domain.Entities.RefreshToken refreshToken = await refreshTokenRepository.GetByUserAndTenantIdentifierAsync(userIdentifier, tenantIdentifier);

            RefreshTokenDto dto = _mapper.Map<RefreshTokenDto>(refreshToken);

            return dto;
        }

        public async Task SaveAppRefreshTokenAsync(RefreshTokenDto dto)
        {
            IRefreshTokenRepository refreshTokenRepository = _refreshTokenRepositoryFactory.GetInstance(typeof(ApplicationDbContext));

            await refreshTokenRepository.SaveAsync(dto);
        }

        public async Task SetAppUserConnectionString(string userEmail)
        {
            var dbBoostrapped = await _appDbContext.Database.CanConnectAsync();

            if (!dbBoostrapped)
            {
                TenantSetting tenant = await _tenantRepository.GetByUserEmailAsync(userEmail);

                if (tenant?.AdminId.HasValue ?? false) //temporary fix . Root tenant should not login via appFE
                {
                    await _appDbContext.SetConnectionStringAndRunMigration(tenant.ConnectionString);
                }
            }
        }
    }
}
