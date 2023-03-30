using AdvoSecure.Application.Dtos;
using AdvoSecure.Domain.Entities;

namespace AdvoSecure.Application.Interfaces.Repositories
{
    public interface ITenantRepository
    {
        Task<Tenant> Create(TenantDto tenantDto, string userIdentifier);
        Task<Tenant> Get();
        Task<bool> CheckTenantExisted(string azureTenantId);
    }
}
