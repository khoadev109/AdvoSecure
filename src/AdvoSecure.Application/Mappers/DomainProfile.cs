using AdvoSecure.Application.Dtos;
using AdvoSecure.Application.Dtos.MatterDtos;
using AdvoSecure.Domain.Interfaces.Requests;
using AdvoSecure.Security;
using AutoMapper;

namespace AdvoSecure.Application.Mappers
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<MatterSearchRequestDto, MatterSearchRequest>();
            CreateMap<AuthRegisterRequest, RegisterRequest>();
            CreateMap<RefreshTokenDto, RefreshTokenRequest>();
        }
    }
}
