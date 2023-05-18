using AdvoSecure.Application.Dtos.BillingDtos;
using AdvoSecure.Application.Dtos.MatterDtos;
using AdvoSecure.Application.Dtos.Timing;
using AdvoSecure.Application.Extensions;
using AdvoSecure.Application.Interfaces.Services;
using AdvoSecure.Common;
using AdvoSecure.Domain.Entities.Billings;
using AdvoSecure.Domain.Entities.Matters;
using AdvoSecure.Domain.Entities.Timing;
using AdvoSecure.Domain.Interfaces;
using AdvoSecure.Domain.Interfaces.Requests;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AdvoSecure.Application.Services
{
    public class MatterService : ServiceBase, IMatterService
    {
        private readonly IMapper _mapper;
        private readonly IAppUnitOfWork _unitOfWork;

        public MatterService(IMapper mapper, IAppUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResult<IEnumerable<MatterTypeDto>>> GetMatterTypesAsync()
        {
            ServiceResult<IEnumerable<MatterTypeDto>> result = await ExecuteAsync<IEnumerable<MatterTypeDto>>(async () =>
            {
                IEnumerable<MatterType> types = await _unitOfWork.MatterTypeRepository.GetAllAsync();

                IEnumerable<MatterTypeDto> typeDtos = _mapper.Map<IEnumerable<MatterTypeDto>>(types);

                return new ServiceSuccessResult<IEnumerable<MatterTypeDto>>(typeDtos);
            });

            return result;
        }

        public async Task<ServiceResult<IEnumerable<MatterAreaDto>>> GetMatterAreasAsync()
        {
            ServiceResult<IEnumerable<MatterAreaDto>> result = await ExecuteAsync<IEnumerable<MatterAreaDto>>(async () =>
            {
                IEnumerable<MatterArea> areas = await _unitOfWork.MatterAreaRepository.GetAllAsync();

                IEnumerable<MatterAreaDto> areaDtos = _mapper.Map<IEnumerable<MatterAreaDto>>(areas);

                return new ServiceSuccessResult<IEnumerable<MatterAreaDto>>(areaDtos);
            });

            return result;
        }

        public async Task<ServiceResult<IEnumerable<CourtSittingInCityDto>>> GetCourtSittingInCitiesAsync()
        {
            ServiceResult<IEnumerable<CourtSittingInCityDto>> result = await ExecuteAsync<IEnumerable<CourtSittingInCityDto>>(async () =>
            {
                IEnumerable<CourtSittingInCity> courtSittingInCities = await _unitOfWork.CourtSittingInCityRepository.GetAllAsync();

                IEnumerable<CourtSittingInCityDto> courtSittingInCityDtos = _mapper.Map<IEnumerable<CourtSittingInCityDto>>(courtSittingInCities);

                return new ServiceSuccessResult<IEnumerable<CourtSittingInCityDto>>(courtSittingInCityDtos);
            });

            return result;
        }

        public async Task<ServiceResult<IEnumerable<CourtGeoJurisdictionDto>>> GetCourtGeoJurisdictionsAsync()
        {
            ServiceResult<IEnumerable<CourtGeoJurisdictionDto>> result = await ExecuteAsync<IEnumerable<CourtGeoJurisdictionDto>>(async () =>
            {
                IEnumerable<CourtGeoJurisdiction> courtGeo = await _unitOfWork.CourtGeoJurisdictionRepository.GetAllAsync();

                IEnumerable<CourtGeoJurisdictionDto> courtGeoDtos = _mapper.Map<IEnumerable<CourtGeoJurisdictionDto>>(courtGeo);

                return new ServiceSuccessResult<IEnumerable<CourtGeoJurisdictionDto>>(courtGeoDtos);
            });

            return result;
        }

        public async Task<ServiceResult<MatterDto>> GetMatterAsync(string id)
        {
            ServiceResult<MatterDto> result = await ExecuteAsync<MatterDto>(async () =>
            {
                _ = Guid.TryParse(id, out Guid parsedId);

                Matter matter = await _unitOfWork.MatterRepository.GetByIdAsync(parsedId);

                MatterDto matterDto = _mapper.Map<MatterDto>(matter);

                return new ServiceSuccessResult<MatterDto>(matterDto);
            });

            return result;
        }

        public async Task<ServiceResult<IEnumerable<MatterDto>>> SearchMattersAsync(MatterSearchRequestDto requestDto)
        {
            ServiceResult<IEnumerable<MatterDto>> result = await ExecuteAsync<IEnumerable<MatterDto>>(async () =>
            {
                MatterSearchRequest searchRequest = _mapper.Map<MatterSearchRequest>(requestDto);

                IEnumerable<Matter> matters = await _unitOfWork.MatterRepository.SearchAsync(searchRequest);

                IEnumerable<MatterDto> matterDtos = _mapper.Map<IEnumerable<MatterDto>>(matters);

                return new ServiceSuccessResult<IEnumerable<MatterDto>>(matterDtos);
            });

            return result;
        }

        public async Task<ServiceResult<IEnumerable<InvoiceExpenseDto>>> GetExpensesByMatterIdAsync(string id)
        {
            ServiceResult<IEnumerable<InvoiceExpenseDto>> result = await ExecuteAsync<IEnumerable<InvoiceExpenseDto>>(async () =>
            {
                _ = Guid.TryParse(id, out Guid parsedId);

                IEnumerable<InvoiceExpense> invoiceExpenses = await _unitOfWork.InvoiceExpenseRepository.GetQueryable()
                                                        .Include(x => x.Expense)
                                                        .ThenInclude(x => x.Matters)
                                                        .Where(x => x.Expense.Matters.Any(y => y.Id == parsedId)).ToListAsync();

                IEnumerable<InvoiceExpenseDto> dtos = _mapper.Map<IEnumerable<InvoiceExpenseDto>>(invoiceExpenses);

                return new ServiceSuccessResult<IEnumerable<InvoiceExpenseDto>>(dtos);
            });

            return result;
        }

        public async Task<ServiceResult<IEnumerable<ExpenseDto>>> GetUnbilledExpensesByMatterIdAsync(string id)
        {
            ServiceResult<IEnumerable<ExpenseDto>> result = await ExecuteAsync<IEnumerable<ExpenseDto>>(async () =>
            {
                _ = Guid.TryParse(id, out Guid parsedId);

                IEnumerable<Expense> unbilledExpenses = await _unitOfWork.ExpenseRepository.GetUnbilledExpensesByMatterIdAsync(parsedId);

                IEnumerable<ExpenseDto> dtos = _mapper.Map<IEnumerable<ExpenseDto>>(unbilledExpenses);

                return new ServiceSuccessResult<IEnumerable<ExpenseDto>>(dtos);
            });

            return result;
        }

        public async Task<ServiceResult<IEnumerable<InvoiceFeeDto>>> GetBilledFeesByMatterIdAsync(string id)
        {
            ServiceResult<IEnumerable<InvoiceFeeDto>> result = await ExecuteAsync<IEnumerable<InvoiceFeeDto>>(async () =>
            {
                _ = Guid.TryParse(id, out Guid parsedId);

                IEnumerable<InvoiceFee> billedFees = await _unitOfWork.InvoiceFeeRepository.GetQueryable().Include(x => x.Fee).ThenInclude(x => x.Matters).Where(x => x.Fee.Matters.Any(y => y.Id == parsedId)).ToListAsync();

                IEnumerable<InvoiceFeeDto> dtos = _mapper.Map<IEnumerable<InvoiceFeeDto>>(billedFees);

                return new ServiceSuccessResult<IEnumerable<InvoiceFeeDto>>(dtos);
            });

            return result;
        }

        public async Task<ServiceResult<IEnumerable<FeeDto>>> GetUnbilledFeesByMatterIdAsync(string id)
        {
            ServiceResult<IEnumerable<FeeDto>> result = await ExecuteAsync<IEnumerable<FeeDto>>(async () =>
            {
                _ = Guid.TryParse(id, out Guid parsedId);

                IEnumerable<Fee> unbilledFees = await _unitOfWork.FeeRepository.GetUnbilleFeesByMatterIdAsync(parsedId);

                IEnumerable<FeeDto> dtos = _mapper.Map<IEnumerable<FeeDto>>(unbilledFees);

                return new ServiceSuccessResult<IEnumerable<FeeDto>>(dtos);
            });

            return result;
        }

        public async Task<ServiceResult<IEnumerable<InvoiceTimeDto>>> GetInvoiceTimesByMatterIdAsync(string id)
        {
            ServiceResult<IEnumerable<InvoiceTimeDto>> result = await ExecuteAsync<IEnumerable<InvoiceTimeDto>>(async () =>
            {
                _ = Guid.TryParse(id, out Guid parsedId);

                IEnumerable<InvoiceTime> invoiceTimes = await _unitOfWork.InvoiceTimeRepository.GetQueryable().Include(x => x.Time).ThenInclude(x => x.Tasks).ThenInclude(x => x.Matters).Where(x => x.Time.Tasks.Any(y => y.Matters.Any(z => z.Id == parsedId))).ToListAsync();

                IEnumerable<InvoiceTimeDto> dtos = _mapper.Map<IEnumerable<InvoiceTimeDto>>(invoiceTimes);

                return new ServiceSuccessResult<IEnumerable<InvoiceTimeDto>>(dtos);
            });

            return result;
        }

        public async Task<ServiceResult<IEnumerable<TimeDto>>> GetTimesByMatterIdAsync(string id)
        {
            ServiceResult<IEnumerable<TimeDto>> result = await ExecuteAsync<IEnumerable<TimeDto>>(async () =>
            {
                _ = Guid.TryParse(id, out Guid parsedId);

                IEnumerable<Time> unbilledTimes = await _unitOfWork.TimeRepository.GetQueryable().Include(x => x.InvoiceTimes).Include(x => x.Tasks).ThenInclude(x => x.Matters).Where(x => x.Tasks.Any(y => y.Matters.Any(z => z.Id == parsedId)) && x.InvoiceTimes.All(y => y.TimeId != x.Id)).ToListAsync();

                IEnumerable<TimeDto> dtos = _mapper.Map<IEnumerable<TimeDto>>(unbilledTimes);

                return new ServiceSuccessResult<IEnumerable<TimeDto>>(dtos);
            });

            return result;
        }

        public async Task<ServiceResult<MatterDto>> CreateMatterAsync(MatterDto matterDto, string userName, string userCode)
        {
            ServiceResult<MatterDto> result = await ExecuteAsync<MatterDto>(async () =>
            {
                // TODO: set in AutoMapper
                matterDto.BillingGroupId = matterDto.BillingGroupId == 0 ? null : matterDto.BillingGroupId;
                matterDto.MatterAreaId = matterDto.MatterAreaId == 0 ? null : matterDto.MatterAreaId;
                matterDto.CourtSittingInCityId = matterDto.CourtSittingInCityId == 0 ? null : matterDto.CourtSittingInCityId;
                matterDto.CourtGeoJurisdictionId = matterDto.CourtGeoJurisdictionId == 0 ? null : matterDto.CourtGeoJurisdictionId;
                
                Matter newMatter = _mapper.Map<Matter>(matterDto);

                var sequence = await _unitOfWork.MatterRepository.GetLatestSequenceAsync();

                newMatter.MatterNumber = GeneratorExtension.GenerateMatterNumber(sequence, userCode);

                Matter createdMatter = await _unitOfWork.MatterRepository.CreateAsync(newMatter, userName);

                await _unitOfWork.CommitAsync();

                MatterDto createdMatterDto = _mapper.Map<MatterDto>(createdMatter);

                return new ServiceSuccessResult<MatterDto>(createdMatterDto);
            });

            return result;
        }

        public async Task<ServiceResult<MatterDto>> UpdateMatterAsync(string id, MatterDto matterDto, string userName)
        {
            ServiceResult<MatterDto> result = await ExecuteAsync<MatterDto>(async () =>
            {
                matterDto.Id = id;

                _ = Guid.TryParse(id, out Guid parsedId);

                // TODO: set in AutoMapper
                matterDto.BillingGroupId = matterDto.BillingGroupId == 0 ? null : matterDto.BillingGroupId;
                matterDto.MatterAreaId = matterDto.MatterAreaId == 0 ? null : matterDto.MatterAreaId;
                matterDto.CourtSittingInCityId = matterDto.CourtSittingInCityId == 0 ? null : matterDto.CourtSittingInCityId;
                matterDto.CourtGeoJurisdictionId = matterDto.CourtGeoJurisdictionId == 0 ? null : matterDto.CourtGeoJurisdictionId;

                Matter existingMatter = await _unitOfWork.MatterRepository.GetAsync(x => x.Id == parsedId);

                existingMatter.CreatedBy = userName;
                existingMatter = _mapper.Map(matterDto, existingMatter);

                Matter updatedMatter = _unitOfWork.MatterRepository.Update(existingMatter, userName);

                await _unitOfWork.CommitAsync();

                MatterDto updatedMatterDto = _mapper.Map<MatterDto>(updatedMatter);

                return new ServiceSuccessResult<MatterDto>(updatedMatterDto);
            });

            return result;
        }
    }
}
