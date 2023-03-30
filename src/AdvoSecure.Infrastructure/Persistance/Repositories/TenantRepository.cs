using AdvoSecure.Application.Dtos;
using AdvoSecure.Application.Interfaces.Repositories;
using AdvoSecure.Domain.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AdvoSecure.Infrastructure.Persistance.Repositories
{
    public class TenantRepository : ITenantRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public TenantRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Tenant> Get()
        {
            Tenant tenant = await _dbContext.Tenants.SingleOrDefaultAsync();

            return tenant;
        }

        public async Task<Tenant> Create(TenantDto tenantDto, string userIdentifier)
        {
            try
            {
                tenantDto.CreatedBy = userIdentifier;
                tenantDto.CreatedDateTime = DateTime.Now;

                Tenant tenant = _mapper.Map<Tenant>(tenantDto);

                EntityEntry<Tenant> createdTenant = await _dbContext.Tenants.AddAsync(tenant);

                await _dbContext.SaveChangesAsync();

                return createdTenant.Entity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> CheckTenantExisted(string azureTenantId)
        {
            bool isExisted = await _dbContext.Tenants.AnyAsync(t => t.AzureTenantId == azureTenantId);
            return isExisted;
        }
    }
}
