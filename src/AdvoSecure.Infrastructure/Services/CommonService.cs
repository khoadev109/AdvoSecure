using AdvoSecure.Application.Dtos;
using AdvoSecure.Application.Dtos.BillingDtos;
using AdvoSecure.Application.Interfaces.Services;
using AdvoSecure.Common;
using AdvoSecure.Domain.Entities;
using AdvoSecure.Domain.Entities.Billings;
using AdvoSecure.Domain.Entities.Tasks;
using AdvoSecure.Domain.Interfaces;
using AutoMapper;

namespace AdvoSecure.Infrastructure.Services
{
    public class CommonService : ServiceBase, ICommonService
    {
        private readonly IMapper _mapper;
        private readonly IAppUnitOfWork _unitOfWork;

        public CommonService(IMapper mapper, IAppUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResult<IEnumerable<BillingRateDto>>> GetBillingRatesAsync()
        {
            ServiceResult<IEnumerable<BillingRateDto>> result = await ExecuteAsync<IEnumerable<BillingRateDto>>(async () =>
            {
                IEnumerable<BillingRate> billingRates = await _unitOfWork.BillingRateRepository.GetAllAsync();

                IEnumerable<BillingRateDto> billingRateDtos = _mapper.Map<IEnumerable<BillingRateDto>>(billingRates);

                return new ServiceSuccessResult<IEnumerable<BillingRateDto>>(billingRateDtos);
            });

            return result;
        }

        public async Task<ServiceResult<IEnumerable<BillingGroupDto>>> GetBillingGroupsAsync()
        {
            ServiceResult<IEnumerable<BillingGroupDto>> result = await ExecuteAsync<IEnumerable<BillingGroupDto>>(async () =>
            {
                IEnumerable<BillingGroup> billingGroups = await _unitOfWork.BillingGroupRepository.GetAllAsync();

                IEnumerable<BillingGroupDto> billingGroupDtos = _mapper.Map<IEnumerable<BillingGroupDto>>(billingGroups);

                return new ServiceSuccessResult<IEnumerable<BillingGroupDto>>(billingGroupDtos);
            });

            return result;
        }

        public async Task<ServiceResult<IEnumerable<CompanyLegalStatusDto>>> GetCompanyLegalStatusesAsync()
        {
            ServiceResult<IEnumerable<CompanyLegalStatusDto>> result = await ExecuteAsync<IEnumerable<CompanyLegalStatusDto>>(async () =>
            {
                IEnumerable<CompanyLegalStatus> companyLegalStatuses = await _unitOfWork.CompanyLegalStatusRepository.GetAllAsync();

                IEnumerable<CompanyLegalStatusDto> companyLegalStatusDtos = _mapper.Map<IEnumerable<CompanyLegalStatusDto>>(companyLegalStatuses);

                return new ServiceSuccessResult<IEnumerable<CompanyLegalStatusDto>>(companyLegalStatusDtos);
            });

            return result;
        }

        public async Task<ServiceResult<IEnumerable<CountryDto>>> GetCountriesAsync()
        {
            ServiceResult<IEnumerable<CountryDto>> result = await ExecuteAsync<IEnumerable<CountryDto>>(async () =>
            {
                IEnumerable<Country> countries = await _unitOfWork.CountryRepository.GetAllAsync();

                IEnumerable<CountryDto> countryDtos = _mapper.Map<IEnumerable<CountryDto>>(countries);

                return new ServiceSuccessResult<IEnumerable<CountryDto>>(countryDtos);
            });

            return result;
        }

        public async Task<ServiceResult<IEnumerable<TaskTypeDto>>> GetTaskTypeAsync()
        {
            ServiceResult<IEnumerable<TaskTypeDto>> result = await ExecuteAsync<IEnumerable<TaskTypeDto>>(async () =>
            {
                IEnumerable<TaskType> tasktypes = await _unitOfWork.TaskTypeRepository.GetAllAsync();

                IEnumerable<TaskTypeDto> taskTypeDtos = _mapper.Map<IEnumerable<TaskTypeDto>>(tasktypes);

                return new ServiceSuccessResult<IEnumerable<TaskTypeDto>>(taskTypeDtos);

            });

            return result;
        }
    }
}
