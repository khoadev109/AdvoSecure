using AdvoSecure.Application.Dtos;
using AdvoSecure.Application.Interfaces;
using AdvoSecure.Application.Interfaces.Repositories;
using AdvoSecure.Application.Interfaces.Services;
using AdvoSecure.Common;
using AdvoSecure.Domain.Entities;
using AdvoSecure.Infrastructure.Persistance;
using AdvoSecure.Infrastructure.Persistance.App;
using AdvoSecure.Infrastructure.Persistance.Tenant;
using AdvoSecure.Security;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace AdvoSecure.Infrastructure.Services
{
    public class UserService : ServiceBase, IUserService
    {
        private readonly ApplicationDbContext _appDbContext;
        private readonly IMgmtUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRefreshTokenRepositoryFactory _refreshTokenRepositoryFactory;
        private readonly IMapper _mapper;

        public UserService(ApplicationDbContext appDbContext, IMgmtUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, IRefreshTokenRepositoryFactory refreshTokenRepositoryFactory, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _refreshTokenRepositoryFactory = refreshTokenRepositoryFactory;
            _mapper = mapper;
        }

        public async Task<ServiceResult<bool>> CheckPasswordAsync(string userName, string password)
        {
            ServiceResult<bool> result = await ExecuteAsync<bool>(async () =>
            {
                bool existed = await _unitOfWork.TenantUserRepository.CheckPasswordAsync(userName, password);

                return new ServiceSuccessResult<bool>(existed);
            });

            return result;
        }

        public async Task<ServiceResult<TenantUserDto>> FindByEmailAsync(string email)
        {
            ServiceResult<TenantUserDto> result = await ExecuteAsync<TenantUserDto>(async () =>
            {
                TenantUser user = await _unitOfWork.TenantUserRepository.GetAsync(x => x.Email == email);

                TenantUserDto userDto = _mapper.Map<TenantUserDto>(user);

                return new ServiceSuccessResult<TenantUserDto>(userDto);
            });

            return result;
        }

        public async Task<ServiceResult<TenantUserDto>> FindByUserIdentifierAsync(Guid userIdentifier)
        {
            ServiceResult<TenantUserDto> result = await ExecuteAsync<TenantUserDto>(async () =>
            {
                TenantUser user = await _unitOfWork.TenantUserRepository.GetAsync(x => x.UserIdentifier == userIdentifier);

                TenantUserDto userDto = _mapper.Map<TenantUserDto>(user);

                return new ServiceSuccessResult<TenantUserDto>(userDto);
            });

            return result;
        }

        public async Task<ServiceResult<IEnumerable<TenantUserDto>>> GetAllUsersAsync()
        {
            ServiceResult<IEnumerable<TenantUserDto>> result = await ExecuteAsync<IEnumerable<TenantUserDto>>(async () =>
            {
                IEnumerable<TenantUser> users = await _unitOfWork.TenantUserRepository.GetAllAsync();

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

                TenantUser user = await _unitOfWork.TenantUserRepository.GetAsync(x => x.UserIdentifier == parsedUserIdentifier);

                TenantUser updatedUser = _unitOfWork.TenantUserRepository.Update(user);

                await _unitOfWork.CommitAsync();

                TenantUserDto updatedUserDto = _mapper.Map<TenantUserDto>(updatedUser);

                return new ServiceSuccessResult<TenantUserDto>(updatedUserDto);

            });

            return result;
        }

        public async Task<ServiceResult> SetAppUserConnectionString(string userEmail)
        {
            ServiceResult result = await ExecuteAsync(async () =>
            {
                TenantSetting tenant = await _unitOfWork.TenantSettingRepository.GetByUserEmailAsync(userEmail);

                if (tenant?.AdminId.HasValue ?? false) //temporary fix . Root tenant should not login via appFE
                {
                    await _appDbContext.SetConnectionStringAndRunMigration(tenant.ConnectionString);
                }

                return new ServiceSuccessResult();
            });

            return result;
        }


        // TechDept RefreshToken

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
    }
}
