﻿using AdvoSecure.Application.Dtos;
using AdvoSecure.Application.Dtos.BillingDtos;
using AdvoSecure.Application.Dtos.ContactDtos;
using AdvoSecure.Application.Dtos.MatterDtos;
using AdvoSecure.Application.Dtos.Notes;
using AdvoSecure.Domain.Entities;
using AdvoSecure.Domain.Entities.Billings;
using AdvoSecure.Domain.Entities.Contacts;
using AdvoSecure.Domain.Entities.Matters;
using AdvoSecure.Domain.Entities.Notes;
using AdvoSecure.Domain.Entities.Tasks;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace AdvoSecure.Application.Mappers
{
    public static class AutoMapperApplicationConfig
    {
        public static IServiceCollection AddApplicationMappers(this IServiceCollection services)
        {
            services.AddAutoMapper(config =>
            {
                config.CreateMap<TenantSetting, TenantSettingDto>().ReverseMap()
                    .ForMember(x => x.Id, x => x.Ignore())
                    .ForMember(x => x.ModifiedBy, x => x.Ignore())
                    .ForMember(x => x.ModifiedDateTime, x => x.Ignore())
                    .ForMember(x => x.DeletedBy, x => x.Ignore())
                    .ForMember(x => x.DeletedDateTime, x => x.Ignore());

                config.CreateMap<TenantBilling, TenantBillingDto>().ReverseMap()
                    .ForMember(x => x.Id, x => x.Ignore())
                    .ForMember(x => x.ModifiedBy, x => x.Ignore())
                    .ForMember(x => x.ModifiedDateTime, x => x.Ignore())
                    .ForMember(x => x.DeletedBy, x => x.Ignore())
                    .ForMember(x => x.DeletedDateTime, x => x.Ignore());

                config.CreateMap<TenantUser, TenantUserDto>().ReverseMap()
                    .ForMember(x => x.Id, x => x.Ignore())
                    .ForMember(x => x.ModifiedBy, x => x.Ignore())
                    .ForMember(x => x.ModifiedDateTime, x => x.Ignore())
                    .ForMember(x => x.DeletedBy, x => x.Ignore())
                    .ForMember(x => x.DeletedDateTime, x => x.Ignore());

                config.CreateMap<Country, CountryDto>().ReverseMap()
                    .ForMember(x => x.Id, x => x.Ignore())
                    .ForMember(x => x.ModifiedBy, x => x.Ignore())
                    .ForMember(x => x.ModifiedDateTime, x => x.Ignore())
                    .ForMember(x => x.DeletedBy, x => x.Ignore())
                    .ForMember(x => x.DeletedDateTime, x => x.Ignore());

                config.CreateMap<RefreshToken, RefreshTokenDto>().ReverseMap();

                config.MapCommon();

                config.MapContacts();

                config.MapMatters();

                config.MapNotes();
            });

            return services;
        }

        private static void MapCommon(this IMapperConfigurationExpression config)
        {
            config.CreateMap<BillingRate, BillingRateDto>().ReverseMap()
                    .ForMember(x => x.Id, x => x.Ignore())
                    .ForMember(x => x.ModifiedBy, x => x.Ignore())
                    .ForMember(x => x.ModifiedDateTime, x => x.Ignore())
                    .ForMember(x => x.DeletedBy, x => x.Ignore())
                    .ForMember(x => x.DeletedDateTime, x => x.Ignore());

            config.CreateMap<BillingGroup, BillingGroupDto>().ReverseMap()
                    .ForMember(x => x.Id, x => x.Ignore())
                    .ForMember(x => x.ModifiedBy, x => x.Ignore())
                    .ForMember(x => x.ModifiedDateTime, x => x.Ignore())
                    .ForMember(x => x.DeletedBy, x => x.Ignore())
                    .ForMember(x => x.DeletedDateTime, x => x.Ignore());

            config.CreateMap<CompanyLegalStatus, CompanyLegalStatusDto>().ReverseMap()
                    .ForMember(x => x.Id, x => x.Ignore())
                    .ForMember(x => x.ModifiedBy, x => x.Ignore())
                    .ForMember(x => x.ModifiedDateTime, x => x.Ignore())
                    .ForMember(x => x.DeletedBy, x => x.Ignore())
                    .ForMember(x => x.DeletedDateTime, x => x.Ignore());
        }

        private static void MapContacts(this IMapperConfigurationExpression config)
        {
            config.CreateMap<ContactIdType, ContactIdTypeDto>().ReverseMap()
                    .ForMember(x => x.Id, x => x.Ignore())
                    .ForMember(x => x.ModifiedBy, x => x.Ignore())
                    .ForMember(x => x.ModifiedDateTime, x => x.Ignore())
                    .ForMember(x => x.DeletedBy, x => x.Ignore())
                    .ForMember(x => x.DeletedDateTime, x => x.Ignore());

            config.CreateMap<ContactCivilStatus, ContactCivilStatusDto>().ReverseMap()
                    .ForMember(x => x.Id, x => x.Ignore())
                    .ForMember(x => x.ModifiedBy, x => x.Ignore())
                    .ForMember(x => x.ModifiedDateTime, x => x.Ignore())
                    .ForMember(x => x.DeletedBy, x => x.Ignore())
                    .ForMember(x => x.DeletedDateTime, x => x.Ignore());

            config.CreateMap<Contact, ContactDto>().ReverseMap()
                    .ForMember(x => x.Id, x => x.Ignore())
                    .ForMember(x => x.ModifiedBy, x => x.Ignore())
                    .ForMember(x => x.ModifiedDateTime, x => x.Ignore())
                    .ForMember(x => x.DeletedBy, x => x.Ignore())
                    .ForMember(x => x.DeletedDateTime, x => x.Ignore());

            config.CreateMap<Language, LanguageDto>().ReverseMap()
                    .ForMember(x => x.Id, x => x.Ignore())
                    .ForMember(x => x.ModifiedBy, x => x.Ignore())
                    .ForMember(x => x.ModifiedDateTime, x => x.Ignore())
                    .ForMember(x => x.DeletedBy, x => x.Ignore())
                    .ForMember(x => x.DeletedDateTime, x => x.Ignore());
            
            config.CreateMap<TaskType, TaskTypeDto>().ReverseMap()
                    .ForMember(x => x.Id, x => x.Ignore())
                    .ForMember(x => x.ModifiedBy, x => x.Ignore())
                    .ForMember(x => x.ModifiedDateTime, x => x.Ignore())
                    .ForMember(x => x.DeletedBy, x => x.Ignore())
                    .ForMember(x => x.DeletedDateTime, x => x.Ignore());
        }

        private static void MapMatters(this IMapperConfigurationExpression config)
        {
            config.CreateMap<MatterType, MatterTypeDto>().ReverseMap()
                    .ForMember(x => x.Id, x => x.Ignore())
                    .ForMember(x => x.ModifiedBy, x => x.Ignore())
                    .ForMember(x => x.ModifiedDateTime, x => x.Ignore())
                    .ForMember(x => x.DeletedBy, x => x.Ignore())
                    .ForMember(x => x.DeletedDateTime, x => x.Ignore());

            config.CreateMap<MatterArea, MatterAreaDto>().ReverseMap()
                    .ForMember(x => x.Id, x => x.Ignore())
                    .ForMember(x => x.ModifiedBy, x => x.Ignore())
                    .ForMember(x => x.ModifiedDateTime, x => x.Ignore())
                    .ForMember(x => x.DeletedBy, x => x.Ignore())
                    .ForMember(x => x.DeletedDateTime, x => x.Ignore());

            config.CreateMap<CourtSittingInCity, CourtSittingInCityDto>().ReverseMap()
                    .ForMember(x => x.Id, x => x.Ignore())
                    .ForMember(x => x.ModifiedBy, x => x.Ignore())
                    .ForMember(x => x.ModifiedDateTime, x => x.Ignore())
                    .ForMember(x => x.DeletedBy, x => x.Ignore())
                    .ForMember(x => x.DeletedDateTime, x => x.Ignore());

            config.CreateMap<CourtGeographicalJurisdiction, CourtGeographicalJurisdictionDto>().ReverseMap()
                    .ForMember(x => x.Id, x => x.Ignore())
                    .ForMember(x => x.ModifiedBy, x => x.Ignore())
                    .ForMember(x => x.ModifiedDateTime, x => x.Ignore())
                    .ForMember(x => x.DeletedBy, x => x.Ignore())
                    .ForMember(x => x.DeletedDateTime, x => x.Ignore());

            config.CreateMap<Matter, MatterDto>()
                    .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id.ToString()))
                    .ReverseMap()
                    .ForMember(x => x.Id, x => x.Ignore())
                    .ForMember(x => x.ModifiedBy, x => x.Ignore())
                    .ForMember(x => x.ModifiedDateTime, x => x.Ignore())
                    .ForMember(x => x.DeletedBy, x => x.Ignore())
                    .ForMember(x => x.DeletedDateTime, x => x.Ignore());

            config.CreateMap<MatterContact, MatterContactDto>()
                    .ForMember(x => x.MatterId, x => x.Ignore())
                    .ReverseMap()
                    .ForMember(x => x.MatterId, x => x.Ignore())
                    .ForMember(x => x.Id, x => x.Ignore())
                    .ForMember(x => x.ModifiedBy, x => x.Ignore())
                    .ForMember(x => x.ModifiedDateTime, x => x.Ignore())
                    .ForMember(x => x.DeletedBy, x => x.Ignore())
                    .ForMember(x => x.DeletedDateTime, x => x.Ignore());
        }

        private static void MapNotes(this IMapperConfigurationExpression config)
        {
            config.CreateMap<Note, NoteDto>()
                    .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id.ToString()))
                    .ReverseMap()
                    .ForMember(x => x.Id, x => x.Ignore())
                    .ForMember(x => x.ModifiedBy, x => x.Ignore())
                    .ForMember(x => x.ModifiedDateTime, x => x.Ignore())
                    .ForMember(x => x.DeletedBy, x => x.Ignore())
                    .ForMember(x => x.DeletedDateTime, x => x.Ignore());
        }
    }
}
