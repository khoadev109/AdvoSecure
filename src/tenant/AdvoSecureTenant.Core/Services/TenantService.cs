using AdvoSecureTenant.Core.Persistance;
using AdvoSecureTenant.Core.Persistance.Entities;
using AdvoSecureTenant.Core.Services.Dtos;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;

namespace AdvoSecureTenant.Core.Services
{
    public class TenantService
    {
        private readonly TenantDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public TenantService(TenantDbContext dbContext, IMapper mapper, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<List<TenantDto>> GetAllTenants()
        {
            List<Tenant> tenants = await _dbContext.Tenants.ToListAsync();

            return _mapper.Map<List<TenantDto>>(tenants);
        }

        public async Task<TenantDto> GetByAzureTenantId(string azureTenantId)
        {
            Tenant tenant = await _dbContext.Tenants.FirstOrDefaultAsync(t => t.AzureTenantId == azureTenantId);

            return _mapper.Map<TenantDto>(tenant);
        }

        public async Task<CheckExistingTenantResponseDto> CheckTenantExist(string azureTenantId)
        {
            Tenant tenant = await _dbContext.Tenants.FirstOrDefaultAsync(t => t.AzureTenantId == azureTenantId);
            if (tenant != null)
            {
                return new CheckExistingTenantResponseDto
                {
                    AzureTenantId = tenant.AzureTenantId,
                    IsTenantAdmin = !tenant.AdminTenantId.HasValue,
                    Result = true
                };
            }

            return new CheckExistingTenantResponseDto
            {
                AzureTenantId = azureTenantId,
                IsTenantAdmin = false,
                Result = false
            };
        }

        public async Task<bool> CheckValidTenant(string azureTenantId)
        {
            Tenant adminTenant = await _dbContext.Tenants.FirstOrDefaultAsync(t => !t.AdminTenantId.HasValue);

            if (adminTenant == null)
            {
                return false;
            }

            bool isValid = await _dbContext.TenantSettings.AnyAsync(t => t.AdminTenantId == adminTenant.Id && t.AvailableTenants.Contains(azureTenantId));

            return isValid;
        }

        public async Task<TenantDto> CreateTenant(TenantDto newTenantDto)
        {
            Tenant adminTenant = await _dbContext.Tenants.FirstOrDefaultAsync(t => !t.AdminTenantId.HasValue);

            if (adminTenant == null)
            {
                return new TenantDto();
            }

            bool exisingTenant = await _dbContext.Tenants.AnyAsync(t => t.AzureTenantId == newTenantDto.AzureTenantId);

            if (exisingTenant)
            {
                return new TenantDto();
            }

            Tenant newTenant = null;

            newTenantDto.AdminTenantId = adminTenant.Id;

            newTenantDto.ConnectionString = _configuration["TenantSettings:ConnectionStringTemplate"].Replace("{tenantDbName}", newTenantDto.SchemaName);

            newTenant = _mapper.Map<Tenant>(newTenantDto);

            EntityEntry<Tenant> createdTenant = await _dbContext.AddAsync<Tenant>(newTenant);

            await _dbContext.SaveChangesAsync();

            TenantDto createdTenantDto = _mapper.Map<TenantDto>(createdTenant.Entity);

            return createdTenantDto;
        }
    }
}
