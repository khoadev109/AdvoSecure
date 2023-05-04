using AdvoSecure.Domain.Entities.Base;

namespace AdvoSecure.Domain.Entities.Leads
{
    public class LeadSource : BaseEntity
    {
        public string Title { get; set; }

        public string AdditionalQuestion1 { get; set; }

        public string AdditionalData1 { get; set; }

        public string AdditionalQuestion2 { get; set; }

        public string AdditionalData2 { get; set; }

        public int? TypeId { get; set; }

        public LeadSourceType Type { get; set; }

        public int? ContactId { get; set; }

        public Contacts.Contact Contact { get; set; }

        public IList<Lead> Leads { get; set; } = new List<Lead>();
    }
}
