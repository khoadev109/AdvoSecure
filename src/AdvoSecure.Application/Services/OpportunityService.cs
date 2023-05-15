using AdvoSecure.Application.Dtos.OpportunityDtos;
using AdvoSecure.Application.Interfaces.Services;
using AdvoSecure.Common;
using AdvoSecure.Domain.Entities.Opportunities;
using AdvoSecure.Domain.Interfaces;
using AutoMapper;

namespace AdvoSecure.Application.Services
{
    public class OpportunityService : ServiceBase, IOpportunityService
    {
        private readonly IMapper _mapper;
        private readonly IAppUnitOfWork _unitOfWork;

        public OpportunityService(IMapper mapper, IAppUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResult<IEnumerable<OpportunityDto>>> GetOpportunitiesByMatterIdAsync(string matterId)
        {
            ServiceResult<IEnumerable<OpportunityDto>> result = await ExecuteAsync<IEnumerable<OpportunityDto>>(async () =>
            {
                _ = Guid.TryParse(matterId, out Guid parsedId);

                IEnumerable<Opportunity> opportunities = await _unitOfWork.OpportunityRepository.GetByMatterIdAsync(parsedId);

                IEnumerable<OpportunityDto> opportunityDtos = _mapper.Map<IEnumerable<OpportunityDto>>(opportunities);

                return new ServiceSuccessResult<IEnumerable<OpportunityDto>>(opportunityDtos);
            });

            return result;
        }
    }
}
