using AdvoSecure.Application.Dtos;
using AdvoSecure.Application.Interfaces;
using AdvoSecure.Application.Interfaces.Services;
using AdvoSecure.Common;
using AdvoSecure.Domain.Entities;
using AdvoSecure.Domain.Interfaces.Requests;
using AdvoSecure.Infrastructure.Persistance;
using AdvoSecure.Infrastructure.Persistance.App;
using AdvoSecure.Security;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace AdvoSecure.Infrastructure.Services
{
    public class TenantService : ServiceBase, ITenantService
    {
        private readonly IMapper _mapper;
        private readonly IMgmtUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _appDbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public TenantService(IMapper mapper, IMgmtUnitOfWork unitOfWork, ApplicationDbContext appDbContext, UserManager<ApplicationUser> userManager)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _appDbContext = appDbContext;
            _userManager = userManager;
        }

        public async Task<ServiceResult<TenantSettingDto>> GetCurrentTenantAsync(Guid identifier, Guid adminIdentifier)
        {
            ServiceResult<TenantSettingDto> result = await ExecuteAsync<TenantSettingDto>(async () =>
            {
                TenantSetting tenant = await _unitOfWork.TenantSettingRepository.GetAsync(x => x.TenantIdentifier == identifier);

                TenantSettingDto dto = _mapper.Map<TenantSettingDto>(tenant);

                return new ServiceSuccessResult<TenantSettingDto>(dto);
            });

            return result;
        }

        public async Task<ServiceResult<TenantSettingDto>> GetTenantAdminByUserIdentifierAsync(Guid userIdentifier)
        {
            ServiceResult<TenantSettingDto> result = await ExecuteAsync<TenantSettingDto>(async () =>
            {
                TenantSetting tenant = await _unitOfWork.TenantSettingRepository.GetByUserIdentifierAsync(userIdentifier);

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
                TenantSetting tenant = await _unitOfWork.TenantSettingRepository.GetByUserIdentifierAsync(userIdentifier);

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
                TenantSetting tenant = await _unitOfWork.TenantSettingRepository.GetAsync(x => x.Id == id);

                TenantSettingDto dto = _mapper.Map<TenantSettingDto>(tenant);

                return new ServiceSuccessResult<TenantSettingDto>(dto);
            });

            return result;
        }

        public async Task<ServiceResult<TenantSettingDto>> GetTenantAdminAsync(Guid adminIdentifier)
        {
            ServiceResult<TenantSettingDto> result = await ExecuteAsync<TenantSettingDto>(async () =>
            {
                TenantSetting tenant = await _unitOfWork.TenantSettingRepository.GetAdminAsync(adminIdentifier);

                TenantSettingDto dto = _mapper.Map<TenantSettingDto>(tenant);

                return new ServiceSuccessResult<TenantSettingDto>(dto);
            });

            return result;
        }

        public async Task<ServiceResult<TenantSettingDto>> GetTenantAdminAsync(int id)
        {
            ServiceResult<TenantSettingDto> result = await ExecuteAsync<TenantSettingDto>(async () =>
            {
                TenantSetting tenant = await _unitOfWork.TenantSettingRepository.GetAdminAsync(id);

                TenantSettingDto dto = _mapper.Map<TenantSettingDto>(tenant);

                return new ServiceSuccessResult<TenantSettingDto>(dto);
            });

            return result;
        }

        public async Task<ServiceResult<IEnumerable<TenantSettingDto>>> GetAllTenantsAsync()
        {
            ServiceResult<IEnumerable<TenantSettingDto>> result = await ExecuteAsync<IEnumerable<TenantSettingDto>>(async () =>
            {
                IEnumerable<TenantSetting> tenants = await _unitOfWork.TenantSettingRepository.GetAllAsync();

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

                TenantUser newAdmin = await _unitOfWork.TenantUserRepository.CreateAsync(domainRegisterRequest, userName);

                TenantSetting tenantAdmin = await _unitOfWork.TenantSettingRepository.GetAdminAsync(request.TenantAdminIdentifier);

                TenantDirectory mappedDirectory = await _unitOfWork.TenantDirectoryRepository.CreateAsync(tenantAdmin, newAdmin, userName);

                if (mappedDirectory == null)
                {
                    return new ServiceFailResult<TenantUserDto>();
                }

                TenantUserDto newAdminDto = _mapper.Map<TenantUserDto>(newAdmin);

                await _unitOfWork.CommitAsync();

                return new ServiceSuccessResult<TenantUserDto>(newAdminDto);

            },
            async () => await _unitOfWork.RollbackAsync());

            return result;
        }

        private async Task<ServiceResult<TenantUserDto>> RegisterAsUserAsync(AuthRegisterRequest request, string userName)
        {
            ServiceResult<TenantUserDto> result = await ExecuteAsync<TenantUserDto>(async () =>
            {
                _ = Guid.TryParse(request.TenantIdentifier, out Guid parsedTenantIdentifier);

                TenantSetting tenant = await _unitOfWork.TenantSettingRepository.GetAsync(x => x.TenantIdentifier == parsedTenantIdentifier);

                tenant ??= await _unitOfWork.TenantSettingRepository.CreateAsync(request.TenantAdminIdentifier);

                RegisterRequest domainRegisterRequest = _mapper.Map<RegisterRequest>(request);

                TenantUser newUser = await _unitOfWork.TenantUserRepository.CreateAsync(domainRegisterRequest, userName);

                await _appDbContext.SetConnectionStringAndRunMigration(tenant.ConnectionString);


                TenantDirectory mappedDirectory = await _unitOfWork.TenantDirectoryRepository.CreateAsync(tenant, newUser, userName);

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

                await _unitOfWork.CommitAsync();

                if (result.Succeeded)
                {
                    TenantUserDto userDto = _mapper.Map<TenantUserDto>(newUser);

                    return new ServiceSuccessResult<TenantUserDto>(userDto);
                }

                return new ServiceFailResult<TenantUserDto>();
            },
            async () => await _unitOfWork.RollbackAsync());

            return result;
        }
    }
}
