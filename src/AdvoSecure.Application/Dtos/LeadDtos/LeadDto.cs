using AdvoSecure.Application.Dtos.ContactDtos;
using AdvoSecure.Domain.Entities.Leads;

namespace AdvoSecure.Application.Dtos.LeadDtos
{
    public class LeadDto
    {
        public long Id { get; set; }

        public DateTime? Closed { get; set; }

        public string Details { get; set; }

        public int? StatusId { get; set; }

        public LeadStatusDto Status { get; set; }

        public int? ContactId { get; set; }

        public ContactDto Contact { get; set; }

        public int? SourceId { get; set; }

        public LeadSourceDto Source { get; set; }

        public int? FeeId { get; set; }

        public LeadFeeDto Fee { get; set; }
    }
}
