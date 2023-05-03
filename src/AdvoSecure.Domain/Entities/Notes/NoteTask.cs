using AdvoSecure.Domain.Entities.Base;

namespace AdvoSecure.Domain.Entities.Notes
{
    public class NoteTask : BaseGuidEntity
    {
        public Guid NoteId { get; set; }

        public Note Note { get; set; }

        public int TaskId { get; set; }

        public Tasks.InnerTask Task { get; set; }
    }
}
