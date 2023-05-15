using AdvoSecure.Application.Dtos.ContactDtos;
using AdvoSecure.Domain.Entities.Base;

namespace AdvoSecure.Application.Dtos.LeadDtos
{
    public class LeadSourceDto : BaseEntity
    {
        public string Title { get; set; }

        public string AdditionalQuestion1 { get; set; }

        public string AdditionalData1 { get; set; }

        public string AdditionalQuestion2 { get; set; }

        public string AdditionalData2 { get; set; }

        public int? TypeId { get; set; }

        public LeadSourceTypeDto Type { get; set; }

        public int? ContactId { get; set; }

        public ContactDto Contact { get; set; }
    }
}
