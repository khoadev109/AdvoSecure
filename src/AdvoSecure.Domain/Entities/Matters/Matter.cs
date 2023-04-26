using AdvoSecure.Domain.Entities.Base;
using AdvoSecure.Domain.Entities.Billings;
using AdvoSecure.Domain.Entities.Contacts;
using AdvoSecure.Domain.Entities.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvoSecure.Domain.Entities.Matters
{
    [Table("Matters")]
    public class Matter : AuditableEntity<Guid>
    {
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

        public MatterType MatterType { get; set; }

        public int? BillingGroupId { get; set; }

        public BillingGroup BillingGroup { get; set; }

        public int? BillToContactId { get; set; }

        public Contact BillToContact { get; set; }

        public int? DefaultBillingRateId { get; set; }

        public BillingRate DefaultBillingRate { get; set; }

        public int? MatterAreaId { get; set; }

        public MatterArea MatterArea { get; set; }

        public int? CourtGeographicalJurisdictionId { get; set; }

        public CourtGeographicalJurisdiction CourtGeographicalJurisdiction { get; set; }

        public int? CourtSittingInCityId { get; set; }

        public CourtSittingInCity CourtSittingInCity { get; set; }

        public IList<MatterContact> MatterContacts { get; set; } = new List<MatterContact>();

        public IList<TaskMatter> TaskMatters { get; set; } = new List<TaskMatter>();
    }
}
