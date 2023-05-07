using AdvoSecure.Domain.Entities.Base;
using AdvoSecure.Domain.Entities.Matters;
using AdvoSecure.Domain.Entities.Tasks;

namespace AdvoSecure.Domain.Entities.Notes
{
    public class Note : BaseGuidEntity
    {
        public string Title { get; set; }

        public string Body { get; set; }

        public DateTime? Timestamp { get; set; } = null;

        public IList<Matter> Matters { get; set; } = new List<Matter>();

        public IList<NoteNotification> NoteNotifications { get; set; } = new List<NoteNotification>();

        public IList<InnerTask> Tasks { get; set; } = new List<InnerTask>();
    }
}
