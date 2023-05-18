using AdvoSecure.Application.Dtos.BillingDtos;
using AdvoSecure.Application.Dtos.ContactDtos;
using AdvoSecure.Domain.Entities.Billings;
using AdvoSecure.Domain.Entities.Contacts;
using AdvoSecure.Domain.Entities.Matters;
using AdvoSecure.Domain.Entities.Tasks;

namespace AdvoSecure.Application.Dtos.MatterDtos
{
    public class MatterDto
    {
        public string Id { get; set; }

        public long? IdInt { get; set; }

        public string MatterNumber { get; set; }

        public string Title { get; set; }

        public Guid? ParentId { get; set; }

        public string Synopsis { get; set; }

        public bool Active { get; set; }

        public string? CaseNumber { get; set; } = string.Empty;

        public string BillToContactDisplayName { get; set; }

        public decimal? MinimumCharge { get; set; }

        public decimal? EstimatedCharge { get; set; }

        public decimal? MaximumCharge { get; set; }

        public bool OverrideMatterRateWithEmployeeRate { get; set; }

        public string? AttorneyForPartyTitle { get; set; } = string.Empty;

        public string? CaptionPlaintiffOrSubjectShort { get; set; } = string.Empty;

        public string? CaptionPlaintiffOrSubjectRegular { get; set; } = string.Empty;

        public string? CaptionPlaintiffOrSubjectLong { get; set; } = string.Empty;

        public string? CaptionOtherPartyShort { get; set; } = string.Empty;

        public string? CaptionOtherPartyRegular { get; set; } = string.Empty;

        public string? CaptionOtherPartyLong { get; set; } = string.Empty;

        public int MatterTypeId { get; set; }

        public MatterTypeDto MatterType { get; set; }

        public int BillToContactId { get; set; }

        public ContactDto BillToContact { get; set; }

        public int DefaultBillingRateId { get; set; }

        public BillingRateDto DefaultBillingRate { get; set; }

        public int? BillingGroupId { get; set; }

        public BillingGroupDto BillingGroup { get; set; }

        public int? MatterAreaId { get; set; }

        public MatterAreaDto MatterArea { get; set; }

        public int? CourtSittingInCityId { get; set; }

        public CourtSittingInCityDto CourtSittingInCity { get; set; }

        public int? CourtGeoJurisdictionId { get; set; } = null;

        public CourtGeoJurisdictionDto CourtGeoJurisdiction { get; set; }

        public IList<MatterContactDto> MatterContacts { get; set; } = new List<MatterContactDto>();
    }
}
