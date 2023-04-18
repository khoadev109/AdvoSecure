using AdvoSecure.Application.Dtos;
using AdvoSecure.Application.Interfaces.Repositories;
using AdvoSecure.Application.Interfaces.Services;
using AdvoSecure.Domain.Entities;
using AutoMapper;

namespace AdvoSecure.Infrastructure.Services
{
    public class CaseService : ICaseService
    {
        private readonly ICaseRepository _CaseRepository;
        private readonly IMapper _mapper;

        public CaseService(ICaseRepository CaseRepository, IMapper mapper)
        {
            _CaseRepository = CaseRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CaseDto>> GetAllAsync()
        {
            IEnumerable<Case> Cases = await _CaseRepository.GetAllAsync();

            IEnumerable<CaseDto> CaseDtos = _mapper.Map<IEnumerable<CaseDto>>(Cases);

            return CaseDtos;
        }
    }
}
