using AdvoSecure.Domain.Entities.Base;

namespace AdvoSecure.Domain.Entities.Notes
{
    public class Note : BaseGuidEntity
    {
        public string Title { get; set; }

        public string Body { get; set; }

        public DateTime? Timestamp { get; set; } = null;

        public IList<NoteMatter> NoteMatters { get; set; } = new List<NoteMatter>();

        public IList<NoteNotification> NoteNotifications { get; set; } = new List<NoteNotification>();

        public IList<NoteTask> NoteTasks { get; set; } = new List<NoteTask>();
    }
}
