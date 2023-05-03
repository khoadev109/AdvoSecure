using AdvoSecure.Domain.Entities.Base;

namespace AdvoSecure.Domain.Entities.Notes
{
    public class NoteNotification : BaseGuidEntity
    {
        public Guid NoteId { get; set; }

        public Note Note { get; set; }

        public int ContactId { get; set; }

        public Contacts.Contact Contact { get; set; }

        public DateTime? Cleared { get; set; }
    }
}
