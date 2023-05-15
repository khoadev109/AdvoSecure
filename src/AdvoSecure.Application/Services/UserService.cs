using AdvoSecure.Application.Dtos;
using AdvoSecure.Application.Interfaces;
using AdvoSecure.Application.Interfaces.Services;
using AdvoSecure.Common;
using AdvoSecure.Domain.Entities;
using AdvoSecure.Domain.Interfaces;
using AdvoSecure.Security;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace AdvoSecure.Application.Services
{
    public class UserService : ServiceBase, IUserService
    {
        private readonly IMgmtUnitOfWork _mgmtUnitOfWork;
        private readonly IAppUnitOfWork _appUnitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public UserService(IMgmtUnitOfWork mgmtUnitOfWork, IAppUnitOfWork appUnitOfWork, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _mgmtUnitOfWork = mgmtUnitOfWork;
            _appUnitOfWork = appUnitOfWork;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<ServiceResult<bool>> CheckPasswordAsync(string userName, string password)
        {
            ServiceResult<bool> result = await ExecuteAsync<bool>(async () =>
            {
                bool existed = await _mgmtUnitOfWork.TenantUserRepository.CheckPasswordAsync(userName, password);

                return new ServiceSuccessResult<bool>(existed);
            });

            return result;
        }

        public async Task<ServiceResult<TenantUserDto>> FindByEmailAsync(string email)
        {
            ServiceResult<TenantUserDto> result = await ExecuteAsync<TenantUserDto>(async () =>
            {
                TenantUser user = await _mgmtUnitOfWork.TenantUserRepository.GetAsync(x => x.Email == email);

                TenantUserDto userDto = _mapper.Map<TenantUserDto>(user);

                return new ServiceSuccessResult<TenantUserDto>(userDto);
            });

            return result;
        }

        public async Task<ServiceResult<TenantUserDto>> FindByUserIdentifierAsync(Guid userIdentifier)
        {
            ServiceResult<TenantUserDto> result = await ExecuteAsync<TenantUserDto>(async () =>
            {
                TenantUser user = await _mgmtUnitOfWork.TenantUserRepository.GetAsync(x => x.UserIdentifier == userIdentifier);

                TenantUserDto userDto = _mapper.Map<TenantUserDto>(user);

                return new ServiceSuccessResult<TenantUserDto>(userDto);
            });

            return result;
        }

        public async Task<ServiceResult<IEnumerable<TenantUserDto>>> GetAllUsersAsync()
        {
            ServiceResult<IEnumerable<TenantUserDto>> result = await ExecuteAsync<IEnumerable<TenantUserDto>>(async () =>
            {
                IEnumerable<TenantUser> users = await _mgmtUnitOfWork.TenantUserRepository.GetAllAsync();

                IEnumerable<TenantUserDto> userDtos = _mapper.Map<IEnumerable<TenantUserDto>>(users);

                return new ServiceSuccessResult<IEnumerable<TenantUserDto>>(userDtos);
            });

            return result;
        }

        public async Task<ServiceResult<ApplicationUser>> UpdateAppUserProfile(AppUserProfileRequestDto request)
        {
            ServiceResult<ApplicationUser> result = await ExecuteAsync<ApplicationUser>(async () =>
            {
                ApplicationUser user = await _userManager.GetUserAsync(request.User);

                if (user == null)
                {
                    return new ServiceFailResult<ApplicationUser>();
                }

                user.DisplayName = request.DisplayName;
                user.FirstName = request.FirstName;
                user.LastName = request.LastName;
                user.Email = request.Email;
                user.UserName = request.Email;

                IdentityResult result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return new ServiceSuccessResult<ApplicationUser>(user);
                }

                return new ServiceFailResult<ApplicationUser>();

            });

            return result;
        }

        public async Task<ServiceResult<TenantUserDto>> UpdateTenantUser(AppUserProfileRequestDto request)
        {
            ServiceResult<TenantUserDto> result = await ExecuteAsync<TenantUserDto>(async () =>
            {
                if (!Guid.TryParse(request.UserIdentifier, out Guid parsedUserIdentifier))
                {
                    return new ServiceFailResult<TenantUserDto>();
                }

                TenantUser user = await _mgmtUnitOfWork.TenantUserRepository.GetAsync(x => x.UserIdentifier == parsedUserIdentifier);

                TenantUser updatedUser = _mgmtUnitOfWork.TenantUserRepository.Update(user);

                await _mgmtUnitOfWork.CommitAsync();

                TenantUserDto updatedUserDto = _mapper.Map<TenantUserDto>(updatedUser);

                return new ServiceSuccessResult<TenantUserDto>(updatedUserDto);

            });

            return result;
        }

        public async Task<ServiceResult> SetAppUserConnectionString(string userEmail)
        {
            ServiceResult result = await ExecuteAsync(async () =>
            {
                TenantSetting tenant = await _mgmtUnitOfWork.TenantSettingRepository.GetByUserEmailAsync(userEmail);

                if (tenant?.AdminId.HasValue ?? false) //temporary fix . Root tenant should not login via appFE
                {
                    await _appUnitOfWork.SetConnectionStringAndRunMigration(tenant.ConnectionString);
                }

                return new ServiceSuccessResult();
            });

            return result;
        }


        //TechDebt: Create common refresh token methods

        public async Task<RefreshTokenDto> GetTenantRefreshTokenAsync(Guid userIdentifier, Guid tenantIdentifier)
        {
            RefreshToken refreshToken = await _mgmtUnitOfWork.RefreshTokenRepository.GetAsync(x => x.UserIdentifier == userIdentifier && x.TenantIdentifier == tenantIdentifier);

            RefreshTokenDto refreshTokenDto = _mapper.Map<RefreshTokenDto>(refreshToken);

            return refreshTokenDto;
        }

        public async Task SaveTenantRefreshTokenAsync(RefreshTokenDto dto)
        {
            try
            {
                RefreshToken existingRefreshToken = await _mgmtUnitOfWork.RefreshTokenRepository.GetAsync(x => x.UserIdentifier == dto.UserIdentifier && x.TenantIdentifier == dto.TenantIdentifier);

                if (existingRefreshToken != null)
                {
                    _mgmtUnitOfWork.RefreshTokenRepository.Remove(existingRefreshToken);
                }

                RefreshToken newRefreshToken = _mapper.Map<RefreshToken>(dto);

                await _mgmtUnitOfWork.RefreshTokenRepository.AddAsync(newRefreshToken);

                await _mgmtUnitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<RefreshTokenDto> GetAppRefreshTokenAsync(Guid userIdentifier, Guid tenantIdentifier)
        {
            RefreshToken refreshToken = await _appUnitOfWork.RefreshTokenRepository.GetAsync(x => x.UserIdentifier == userIdentifier && x.TenantIdentifier == tenantIdentifier);

            RefreshTokenDto refreshTokenDto = _mapper.Map<RefreshTokenDto>(refreshToken);

            return refreshTokenDto;
        }

        public async Task SaveAppRefreshTokenAsync(RefreshTokenDto dto)
        {
            RefreshToken existingRefreshToken = await _appUnitOfWork.RefreshTokenRepository.GetAsync(x => x.UserIdentifier == dto.UserIdentifier && x.TenantIdentifier == dto.TenantIdentifier);

            if (existingRefreshToken != null)
            {
                _appUnitOfWork.RefreshTokenRepository.Remove(existingRefreshToken);
            }

            RefreshToken newRefreshToken = _mapper.Map<RefreshToken>(dto);

            await _appUnitOfWork.RefreshTokenRepository.AddAsync(newRefreshToken);

            await _appUnitOfWork.CommitAsync();
        }
    }
}
