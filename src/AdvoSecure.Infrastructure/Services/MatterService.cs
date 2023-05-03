using AdvoSecure.Application.Dtos.ContactDtos;
using AdvoSecure.Application.Dtos.MatterDtos;
using AdvoSecure.Application.Interfaces;
using AdvoSecure.Application.Interfaces.Services;
using AdvoSecure.Common;
using AdvoSecure.Domain.Entities.Contacts;
using AdvoSecure.Domain.Entities.Matters;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;

namespace AdvoSecure.Infrastructure.Services
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

        public async Task<ServiceResult<IEnumerable<CourtGeographicalJurisdictionDto>>> GetCourtGeographicalJurisdictionsAsync()
        {
            ServiceResult<IEnumerable<CourtGeographicalJurisdictionDto>> result = await ExecuteAsync<IEnumerable<CourtGeographicalJurisdictionDto>>(async () =>
            {
                IEnumerable<CourtGeographicalJurisdiction> courtGeo = await _unitOfWork.CourtGeographicalJurisdictionRepository.GetAllAsync();

                IEnumerable<CourtGeographicalJurisdictionDto> courtGeoDtos = _mapper.Map<IEnumerable<CourtGeographicalJurisdictionDto>>(courtGeo);

                return new ServiceSuccessResult<IEnumerable<CourtGeographicalJurisdictionDto>>(courtGeoDtos);
            });

            return result;
        }

        public async Task<ServiceResult<MatterDto>> GetMatterAsync(string id)
        {
            ServiceResult<MatterDto> result = await ExecuteAsync<MatterDto>(async () =>
            {
                _ = Guid.TryParse(id, out var parsedId);

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
                IEnumerable<Matter> matters = await _unitOfWork.MatterRepository.SearchAsync(requestDto);

                IEnumerable<MatterDto> matterDtos = _mapper.Map<IEnumerable<MatterDto>>(matters);

                return new ServiceSuccessResult<IEnumerable<MatterDto>>(matterDtos);
            });

            return result;
        }

        public async Task<ServiceResult<MatterDto>> CreateMatterAsync(MatterDto matterDto, string userName)
        {
            ServiceResult<MatterDto> result = await ExecuteAsync<MatterDto>(async () =>
            {
                Matter newMatter = _mapper.Map<Matter>(matterDto);

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
