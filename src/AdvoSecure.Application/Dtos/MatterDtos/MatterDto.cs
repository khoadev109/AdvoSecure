﻿using AdvoSecure.Domain.Entities.Billings;
using AdvoSecure.Domain.Entities.Contacts;
using AdvoSecure.Domain.Entities.Matters;
using AdvoSecure.Domain.Entities.Tasks;

namespace AdvoSecure.Application.Dtos.MatterDtos
{
    public class MatterDto
    {
        public Guid Id { get; set; }
        public long IdInt { get; set; }

        public string MatterNumber { get; set; }

        public string Title { get; set; }

        public Guid? ParentId { get; set; }

        public string Synopsis { get; set; }

        public bool Active { get; set; }

        public string CaseNumber { get; set; }

        public string BillToContactDisplayName { get; set; }

        public decimal? MinimumCharge { get; set; }

        public decimal? EstimatedCharge { get; set; }

        public decimal? MaximumCharge { get; set; }

        public bool OverrideMatterRateWithEmployeeRate { get; set; }

        public string AttorneyForPartyTitle { get; set; }

        public string CaptionPlaintiffOrSubjectShort { get; set; }

        public string CaptionPlaintiffOrSubjectRegular { get; set; }

        public string CaptionPlaintiffOrSubjectLong { get; set; }

        public string CaptionOtherPartyShort { get; set; }

        public string CaptionOtherPartyRegular { get; set; }

        public string CaptionOtherPartyLong { get; set; }

        public int? MatterTypeId { get; set; }

        public int? BillingGroupId { get; set; }

        public int? BillToContactId { get; set; }

        public int? DefaultBillingRateId { get; set; }

        public int? MatterAreaId { get; set; }

        public int? CourtGeographicalJurisdictionId { get; set; }

        public int? CourtSittingInCityId { get; set; }
    }
}
