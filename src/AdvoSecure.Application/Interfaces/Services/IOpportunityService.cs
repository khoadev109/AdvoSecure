using AdvoSecure.Application.Dtos.OpportunityDtos;
using AdvoSecure.Common;

namespace AdvoSecure.Application.Interfaces.Services
{
    public interface IOpportunityService
    {
        Task<ServiceResult<IEnumerable<OpportunityDto>>> GetOpportunitiesByMatterIdAsync(string matterId);
    }
}
