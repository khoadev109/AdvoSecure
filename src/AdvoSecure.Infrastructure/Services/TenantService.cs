using AdvoSecure.Application.Dtos;
using AdvoSecure.Application.Interfaces.Repositories;
using AdvoSecure.Application.Interfaces.Services;
using AdvoSecure.Domain.Entities;
using AutoMapper;
using Microsoft.Extensions.Configuration;

namespace AdvoSecure.Infrastructure.Services
{
    public class TenantService : ITenantService
    {
        private readonly ITenantRepository _tenantRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public TenantService(ITenantRepository tenantRepository, IMapper mapper, IConfiguration configuration)
        {
            _tenantRepository = tenantRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<TenantSettingDto> GetCurrentTenant(Guid identifier, Guid adminIdentifier)
        {
            TenantSetting tenant = await _tenantRepository.GetAsync(identifier);

            TenantSettingDto dto = _mapper.Map<TenantSettingDto>(tenant);

            return dto;
        }

        public async Task<TenantSettingDto> GetTenantAdminByUserIdentifier(Guid userIdentifier)
        {
            TenantSetting tenant = await _tenantRepository.GetByUserIdentifierAsync(userIdentifier);

            if (tenant.AdminId.HasValue)
            {
                return null;
            }

            TenantSettingDto dto = _mapper.Map<TenantSettingDto>(tenant);

            return dto;
        }

        public async Task<TenantSettingDto> GetTenantByUserIdentifier(Guid userIdentifier)
        {
            TenantSetting tenant = await _tenantRepository.GetByUserIdentifierAsync(userIdentifier);

            if (!tenant.AdminId.HasValue)
            {
                return null;
            }

            TenantSettingDto dto = _mapper.Map<TenantSettingDto>(tenant);

            return dto;
        }

        public async Task<TenantSettingDto> GetTenantById(int id)
        {
            TenantSetting tenant = await _tenantRepository.GetByIdAsync(id);

            TenantSettingDto dto = _mapper.Map<TenantSettingDto>(tenant);

            return dto;
        }

        public async Task<TenantSettingDto> GetTenantAdmin(Guid adminIdentifier)
        {
            TenantSetting tenant = await _tenantRepository.GetAdminAsync(adminIdentifier);

            TenantSettingDto dto = _mapper.Map<TenantSettingDto>(tenant);

            return dto;
        }

        public async Task<TenantSettingDto> GetTenantAdmin(int id)
        {
            TenantSetting tenant = await _tenantRepository.GetAdminAsync(id);

            TenantSettingDto dto = _mapper.Map<TenantSettingDto>(tenant);

            return dto;
        }

        public IEnumerable<TenantSettingDto> GetAllTenants()
        {
            IEnumerable<TenantSetting> tenants = _tenantRepository.GetAllTenants();

            IEnumerable<TenantSettingDto> tenantDtos = _mapper.Map<IEnumerable<TenantSettingDto>>(tenants);

            return tenantDtos;
        }
    }
}
