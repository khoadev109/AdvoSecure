using AdvoSecure.Domain.Entities.Base;

namespace AdvoSecure.Domain.Entities.Tasks
{
    public class TaskTemplate : BaseEntity
    {
        public string TaskTemplateTitle { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ProjectedStart { get; set; }

        public string DueDate { get; set; }

        public string ProjectedEnd { get; set; }

        public string ActualEnd { get; set; }

        public bool Active { get; set; }
    }
}
