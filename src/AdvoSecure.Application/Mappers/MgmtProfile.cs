using AdvoSecure.Application.Dtos;
using AdvoSecure.Domain.Entities;
using AutoMapper;

namespace AdvoSecure.Application.Mappers
{
    public class MgmtProfile : Profile
    {
        public MgmtProfile()
        {
            CreateMap<TenantSetting, TenantSettingDto>().ReverseMap()
                    .ForMember(x => x.Id, x => x.Ignore())
                    .ForMember(x => x.ModifiedBy, x => x.Ignore())
                    .ForMember(x => x.ModifiedDateTime, x => x.Ignore())
                    .ForMember(x => x.DeletedBy, x => x.Ignore())
                    .ForMember(x => x.DeletedDateTime, x => x.Ignore());

            CreateMap<TenantBilling, TenantBillingDto>().ReverseMap()
                .ForMember(x => x.Id, x => x.Ignore())
                .ForMember(x => x.ModifiedBy, x => x.Ignore())
                .ForMember(x => x.ModifiedDateTime, x => x.Ignore())
                .ForMember(x => x.DeletedBy, x => x.Ignore())
                .ForMember(x => x.DeletedDateTime, x => x.Ignore());

            CreateMap<TenantUser, TenantUserDto>().ReverseMap()
                .ForMember(x => x.Id, x => x.Ignore())
                .ForMember(x => x.ModifiedBy, x => x.Ignore())
                .ForMember(x => x.ModifiedDateTime, x => x.Ignore())
                .ForMember(x => x.DeletedBy, x => x.Ignore())
                .ForMember(x => x.DeletedDateTime, x => x.Ignore());
        }
    }
}
