
using AdvoSecure.Application.Dtos.ContactDtos;
using AdvoSecure.Application.Dtos.LeadDtos;
using AdvoSecure.Application.Dtos.MatterDtos;
using AdvoSecure.Domain.Entities.Contacts;

namespace AdvoSecure.Application.Dtos.OpportunityDtos
{
    public class OpportunityDto
    {
        public long? Id { get; set; }

        public decimal? Probability { get; set; }

        public decimal? Amount { get; set; }

        public DateTime? Closed { get; set; }

        public int? StageId { get; set; }

        public OpportunityStageDto? Stage { get; set; }

        public int? AccountId { get; set; }

        public ContactDto Account { get; set; }

        public long? LeadId { get; set; }

        public LeadDto? Lead { get; set; }

        public Guid? MatterId { get; set; }

        public MatterDto? Matter { get; set; }

        public IList<Contact>? Contacts{ get; set; } = new List<Contact>();
    }
}
