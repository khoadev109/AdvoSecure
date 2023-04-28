using AdvoSecure.Application.Dtos.MatterDtos;
using AdvoSecure.Application.Interfaces.Repositories;
using AdvoSecure.Application.Interfaces.Services;
using AdvoSecure.Domain.Entities.Matters;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AdvoSecure.Infrastructure.Services
{
    public class MatterService : IMatterService
    {
        private readonly IMapper _mapper;
        private readonly IMatterRepository _matterRepository;

        public MatterService(IMapper mapper, IMatterRepository matterRepository)
        {
            _mapper = mapper;
            _matterRepository = matterRepository;
        }

        public async Task<IEnumerable<MatterTypeDto>> GetMatterTypesAsync()
        {
            IList<MatterType> types = await _matterRepository.GetMatterTypes().ToListAsync();

            IEnumerable<MatterTypeDto> typeDtos = _mapper.Map<IEnumerable<MatterTypeDto>>(types);

            return typeDtos;
        }

        public async Task<IEnumerable<MatterAreaDto>> GetMatterAreasAsync()
        {
            IList<MatterArea> areas = await _matterRepository.GetMatterAreas().ToListAsync();

            IEnumerable<MatterAreaDto> areaDtos = _mapper.Map<IEnumerable<MatterAreaDto>>(areas);

            return areaDtos;
        }

        public async Task<IEnumerable<CourtSittingInCityDto>> GetCourtSittingInCitiesAsync()
        {
            IList<CourtSittingInCity> courtSittingInCities = await _matterRepository.GetCourtSittingInCities().ToListAsync();

            IEnumerable<CourtSittingInCityDto> courtSittingInCityDtos = _mapper.Map<IEnumerable<CourtSittingInCityDto>>(courtSittingInCities);

            return courtSittingInCityDtos;
        }

        public async Task<IEnumerable<CourtGeographicalJurisdictionDto>> GetCourtGeographicalJurisdictionsAsync()
        {
            IList<CourtGeographicalJurisdiction> courtGeo = await _matterRepository.GetCourtGeographicalJurisdictions().ToListAsync();

            IEnumerable<CourtGeographicalJurisdictionDto> courtGeoDtos = _mapper.Map<IEnumerable<CourtGeographicalJurisdictionDto >> (courtGeo);

            return courtGeoDtos;
        }

        public async Task<MatterDto> GetMatterAsync(string id)
        {
            _ = Guid.TryParse(id, out var parsedId);

            Matter matter = await _matterRepository.GetMatterByIdAsync(parsedId);

            MatterDto matterDto = _mapper.Map<MatterDto>(matter);

            return matterDto;
        }

        public async Task<IEnumerable<MatterDto>> SearchMattersAsync(MatterSearchRequestDto requestDto)
        {
            IQueryable<Matter> matters = _matterRepository.GetMatters().Include(x => x.BillToContact).Include(x => x.MatterArea);

            if (!string.IsNullOrWhiteSpace(requestDto.Status))
            {
                bool? active = GetActiveStatus(requestDto.Status);

                matters = matters.Where(x => x.Active == active);
            }

            if (!string.IsNullOrWhiteSpace(requestDto.ContactName))
            {
                matters = matters.Where(x => x.BillToContact.DisplayName.Contains(requestDto.ContactName));
            }

            if (!string.IsNullOrWhiteSpace(requestDto.Description))
            {
                matters = matters.Where(x => x.Title.Contains(requestDto.Description));
            }

            if (!string.IsNullOrWhiteSpace(requestDto.CaseNumber))
            {
                matters = matters.Where(x => x.CaseNumber.Contains(requestDto.CaseNumber));
            }

            if (requestDto.MatterAreaId.HasValue && requestDto.MatterAreaId.Value > 0)
            {
                matters = matters.Where(x => x.MatterAreaId == requestDto.MatterAreaId.Value);
            }

            if (requestDto.CourtGeographicalJurisdictionId.HasValue && requestDto.CourtGeographicalJurisdictionId.Value > 0)
            {
                matters = matters.Where(x => x.CourtGeographicalJurisdictionId == requestDto.CourtGeographicalJurisdictionId.Value);
            }

            IList<Matter> filteredMatters = await matters.ToListAsync();

            IEnumerable<MatterDto> filteredMatterDtos = _mapper.Map<IEnumerable<MatterDto>>(filteredMatters);

            return filteredMatterDtos;
        }

        private bool? GetActiveStatus(string status)
        {
            return status switch
            {
                "inactive" => false,
                "both" => null,
                _ => true,
            };
        }

        public async Task<MatterDto> CreateMatterAsync(MatterDto matterDto, string userName)
        {
            Matter newMatter = _mapper.Map<Matter>(matterDto);

            Matter createdMatter = await _matterRepository.Create(newMatter, userName);

            MatterDto createdMatterDto = _mapper.Map<MatterDto>(createdMatter);

            return createdMatterDto;
        }

        public async Task<MatterDto> UpdateMatterAsync(string id, MatterDto matterDto, string userName)
        {
            matterDto.Id = id;

            Matter updatedMatter = await _matterRepository.Update(matterDto, userName);

            MatterDto updatedMatterDto = _mapper.Map<MatterDto>(updatedMatter);

            return updatedMatterDto;
        }
    }
}
