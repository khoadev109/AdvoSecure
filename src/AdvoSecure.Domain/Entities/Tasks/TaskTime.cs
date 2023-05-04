using AdvoSecure.Domain.Entities.Base;

namespace AdvoSecure.Domain.Entities.Tasks
{
    public class TaskTime : BaseGuidEntity
    {
        public int TaskId { get; set; }

        public InnerTask Task { get; set; }

        public Guid TimeId { get; set; }

        public Timing.Time Time { get; set; }
    }
}