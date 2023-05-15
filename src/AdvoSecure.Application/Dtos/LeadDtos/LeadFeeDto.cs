using AdvoSecure.Application.Dtos;
using AdvoSecure.Application.Dtos.ContactDtos;
using AdvoSecure.Domain.Entities.Base;

namespace AdvoSecure.Application.Dtos.LeadDtos
{
    public class LeadFeeDto : BaseDto
    {
        public bool? IsEligible { get; set; }

        public decimal? Amount { get; set; }

        public DateTime? Paid { get; set; }

        public string AdditionalData { get; set; }

        public int? ToId { get; set; }

        public ContactDto To { get; set; }
    }
}
