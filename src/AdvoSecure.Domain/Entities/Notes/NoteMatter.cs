using AdvoSecure.Domain.Entities.Base;

namespace AdvoSecure.Domain.Entities.Notes
{
    public class NoteMatter : BaseGuidEntity
    {
        public Guid NoteId { get; set; }

        public Note Note { get; set; }

        public Guid MatterId { get; set; }

        public Matters.Matter Matter { get; set; }
    }
}