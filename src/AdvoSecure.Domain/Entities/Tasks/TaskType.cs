using AdvoSecure.Domain.Entities.Base;

namespace AdvoSecure.Domain.Entities.Tasks
{
    public class TaskType : BaseEntity
    {
        public string? Title { get; set; }

        public string? Icon { get; set; }

        public string? Group { get; set; }

        public IList<Task> Tasks { get; set; } = new List<Task>();
    }
}
