using AdvoSecure.Application.Dtos;
using AdvoSecure.Application.Interfaces;
using AdvoSecure.Application.Interfaces.Services;
using AdvoSecure.Common;
using AdvoSecure.Domain.Entities;
using AdvoSecure.Domain.Interfaces;
using AdvoSecure.Domain.Interfaces.Requests;
using AdvoSecure.Security;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace AdvoSecure.Application.Services
{
    public class TenantService : ServiceBase, ITenantService
    {
        private readonly IMapper _mapper;
        private readonly IMgmtUnitOfWork _mgmtUnitOfWork;
        private readonly IAppUnitOfWork _appUnitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;

        public TenantService(IMapper mapper, IMgmtUnitOfWork mgmtUnitOfWork, IAppUnitOfWork appUnitOfWork, UserManager<ApplicationUser> userManager)
        {
            _mapper = mapper;
            _mgmtUnitOfWork = mgmtUnitOfWork;
            _appUnitOfWork = appUnitOfWork;
            _userManager = userManager;
        }

        public async Task<ServiceResult<TenantSettingDto>> GetCurrentTenantAsync(Guid identifier, Guid adminIdentifier)
        {
            ServiceResult<TenantSettingDto> result = await ExecuteAsync<TenantSettingDto>(async () =>
            {
                TenantSetting tenant = await _mgmtUnitOfWork.TenantSettingRepository.GetAsync(x => x.TenantIdentifier == identifier);

                TenantSettingDto dto = _mapper.Map<TenantSettingDto>(tenant);

                return new ServiceSuccessResult<TenantSettingDto>(dto);
            });

            return result;
        }

        public async Task<ServiceResult<TenantSettingDto>> GetTenantAdminByUserIdentifierAsync(Guid userIdentifier)
        {
            ServiceResult<TenantSettingDto> result = await ExecuteAsync<TenantSettingDto>(async () =>
            {
                TenantSetting tenant = await _mgmtUnitOfWork.TenantSettingRepository.GetByUserIdentifierAsync(userIdentifier);

                if (tenant.AdminId.HasValue)
                {
                    return new ServiceFailResult<TenantSettingDto>();
                }

                TenantSettingDto dto = _mapper.Map<TenantSettingDto>(tenant);

                return new ServiceSuccessResult<TenantSettingDto>(dto);
            });

            return result;
        }

        public async Task<ServiceResult<TenantSettingDto>> GetTenantByUserIdentifierAsync(Guid userIdentifier)
        {
            ServiceResult<TenantSettingDto> result = await ExecuteAsync<TenantSettingDto>(async () =>
            {
                TenantSetting tenant = await _mgmtUnitOfWork.TenantSettingRepository.GetByUserIdentifierAsync(userIdentifier);

                if (!tenant.AdminId.HasValue)
                {
                    return new ServiceFailResult<TenantSettingDto>();
                }

                TenantSettingDto dto = _mapper.Map<TenantSettingDto>(tenant);

                return new ServiceSuccessResult<TenantSettingDto>(dto);
            });

            return result;
        }

        public async Task<ServiceResult<TenantSettingDto>> GetTenantByIdAsync(int id)
        {
            ServiceResult<TenantSettingDto> result = await ExecuteAsync<TenantSettingDto>(async () =>
            {
                TenantSetting tenant = await _mgmtUnitOfWork.TenantSettingRepository.GetAsync(x => x.Id == id);

                TenantSettingDto dto = _mapper.Map<TenantSettingDto>(tenant);

                return new ServiceSuccessResult<TenantSettingDto>(dto);
            });

            return result;
        }

        public async Task<ServiceResult<TenantSettingDto>> GetTenantAdminAsync(Guid adminIdentifier)
        {
            ServiceResult<TenantSettingDto> result = await ExecuteAsync<TenantSettingDto>(async () =>
            {
                TenantSetting tenant = await _mgmtUnitOfWork.TenantSettingRepository.GetAdminAsync(adminIdentifier);

                TenantSettingDto dto = _mapper.Map<TenantSettingDto>(tenant);

                return new ServiceSuccessResult<TenantSettingDto>(dto);
            });

            return result;
        }

        public async Task<ServiceResult<TenantSettingDto>> GetTenantAdminAsync(int id)
        {
            ServiceResult<TenantSettingDto> result = await ExecuteAsync<TenantSettingDto>(async () =>
            {
                TenantSetting tenant = await _mgmtUnitOfWork.TenantSettingRepository.GetAdminAsync(id);

                TenantSettingDto dto = _mapper.Map<TenantSettingDto>(tenant);

                return new ServiceSuccessResult<TenantSettingDto>(dto);
            });

            return result;
        }

        public async Task<ServiceResult<IEnumerable<TenantSettingDto>>> GetAllTenantsAsync()
        {
            ServiceResult<IEnumerable<TenantSettingDto>> result = await ExecuteAsync<IEnumerable<TenantSettingDto>>(async () =>
            {
                IEnumerable<TenantSetting> tenants = await _mgmtUnitOfWork.TenantSettingRepository.GetAllAsync();

                IEnumerable<TenantSettingDto> tenantDtos = _mapper.Map<IEnumerable<TenantSettingDto>>(tenants);

                return new ServiceSuccessResult<IEnumerable<TenantSettingDto>>(tenantDtos);
            });

            return result;
        }

        public async Task<ServiceResult<TenantUserDto>> RegisterUserAsync(AuthRegisterRequest request, string userName)
        {
            if (request.SetAsAdmin.GetValueOrDefault())
            {
                ServiceResult<TenantUserDto> adminResult = await RegisterAsAdminAsync(request, userName);

                return adminResult;
            }
            else
            {
                ServiceResult<TenantUserDto> userResult = await RegisterAsUserAsync(request, userName);

                return userResult;
            }
        }

        private async Task<ServiceResult<TenantUserDto>> RegisterAsAdminAsync(AuthRegisterRequest request, string userName)
        {
            ServiceResult<TenantUserDto> result = await ExecuteAsync<TenantUserDto>(async () =>
            {
                RegisterRequest domainRegisterRequest = _mapper.Map<RegisterRequest>(request);

                TenantUser newAdmin = await _mgmtUnitOfWork.TenantUserRepository.CreateAsync(domainRegisterRequest, userName);

                TenantSetting tenantAdmin = await _mgmtUnitOfWork.TenantSettingRepository.GetAdminAsync(request.TenantAdminIdentifier);

                TenantDirectory mappedDirectory = await _mgmtUnitOfWork.TenantDirectoryRepository.CreateAsync(tenantAdmin, newAdmin, userName);

                if (mappedDirectory == null)
                {
                    return new ServiceFailResult<TenantUserDto>();
                }

                TenantUserDto newAdminDto = _mapper.Map<TenantUserDto>(newAdmin);

                await _mgmtUnitOfWork.CommitAsync();

                return new ServiceSuccessResult<TenantUserDto>(newAdminDto);

            },
            async () => await _mgmtUnitOfWork.RollbackAsync());

            return result;
        }

        private async Task<ServiceResult<TenantUserDto>> RegisterAsUserAsync(AuthRegisterRequest request, string userName)
        {
            ServiceResult<TenantUserDto> result = await ExecuteAsync<TenantUserDto>(async () =>
            {
                _ = Guid.TryParse(request.TenantIdentifier, out Guid parsedTenantIdentifier);

                TenantSetting tenant = await _mgmtUnitOfWork.TenantSettingRepository.GetAsync(x => x.TenantIdentifier == parsedTenantIdentifier);

                tenant ??= await _mgmtUnitOfWork.TenantSettingRepository.CreateAsync(request.TenantAdminIdentifier);

                RegisterRequest domainRegisterRequest = _mapper.Map<RegisterRequest>(request);

                TenantUser newUser = await _mgmtUnitOfWork.TenantUserRepository.CreateAsync(domainRegisterRequest, userName);

                await _appUnitOfWork.SetConnectionStringAndRunMigration(tenant.ConnectionString);


                TenantDirectory mappedDirectory = await _mgmtUnitOfWork.TenantDirectoryRepository.CreateAsync(tenant, newUser, userName);

                if (mappedDirectory == null)
                {
                    return new ServiceFailResult<TenantUserDto>();
                }

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

                await _mgmtUnitOfWork.CommitAsync();

                if (result.Succeeded)
                {
                    TenantUserDto userDto = _mapper.Map<TenantUserDto>(newUser);

                    return new ServiceSuccessResult<TenantUserDto>(userDto);
                }

                return new ServiceFailResult<TenantUserDto>();
            },
            async () => await _mgmtUnitOfWork.RollbackAsync());

            return result;
        }
    }
}
