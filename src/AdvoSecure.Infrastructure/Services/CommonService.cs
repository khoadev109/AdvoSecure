using AdvoSecure.Application.Dtos;
using AdvoSecure.Application.Dtos.BillingDtos;
using AdvoSecure.Application.Interfaces.Repositories;
using AdvoSecure.Application.Interfaces.Services;
using AdvoSecure.Domain.Entities;
using AdvoSecure.Domain.Entities.Billings;
using AdvoSecure.Domain.Entities.Language;
using AdvoSecure.Domain.Entities.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AdvoSecure.Infrastructure.Services
{
    public class CommonService : ICommonService
    {
        private readonly ICommonRepository _commonRepository;
        private readonly IMapper _mapper;

        public CommonService(ICommonRepository commonRepository, IMapper mapper)
        {
            _commonRepository = commonRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BillingRateDto>> GetBillingRatesAsync()
        {
            IList<BillingRate> billingRates = await _commonRepository.GetBillingRates().ToListAsync();

            IEnumerable<BillingRateDto> billingRateDtos = _mapper.Map<IEnumerable<BillingRateDto>>(billingRates);

            return billingRateDtos;
        }

        public async Task<IEnumerable<BillingGroupDto>> GetBillingGroupsAsync()
        {
            IList<BillingGroup> billingGroups = await _commonRepository.GetBillingGroups().ToListAsync();

            IEnumerable<BillingGroupDto> billingGroupDtos = _mapper.Map<IEnumerable<BillingGroupDto>>(billingGroups);

            return billingGroupDtos;
        }

        public async Task<IEnumerable<CompanyLegalStatusDto>> GetCompanyLegalStatusesAsync()
        {
            IList<CompanyLegalStatus> companyLegalStatuses = await _commonRepository.GetCompanyLegalStatuses().ToListAsync();

            IEnumerable<CompanyLegalStatusDto> companyLegalStatusDtos = _mapper.Map<IEnumerable<CompanyLegalStatusDto>>(companyLegalStatuses);

            return companyLegalStatusDtos;
        }

        public async Task<IEnumerable<CountryDto>> GetCountriesAsync()
        {
            IList<Country> countries = await _commonRepository.GetCountries().ToListAsync();

            IEnumerable<CountryDto> countryDtos = _mapper.Map<IEnumerable<CountryDto>>(countries);

            return countryDtos;
        }

        public async Task<IEnumerable<LanguageDto>> GetLanguagesAsync()
        {
            IList<Language> languages = await _commonRepository.GetLanguages().ToListAsync();

            IEnumerable<LanguageDto> languageDtos = _mapper.Map<IEnumerable<LanguageDto>>(languages);

            return languageDtos;
        }

        public async Task<IEnumerable<TaskTypeDto>> GetTaskTypeAsync()
        {
            IList<TaskType> tasktypes = await _commonRepository.GetTaskTypes().ToListAsync();

            IEnumerable<TaskTypeDto> taskTypeDtos = _mapper.Map<IEnumerable<TaskTypeDto>>(tasktypes);

            return taskTypeDtos;
        }
    }
}
