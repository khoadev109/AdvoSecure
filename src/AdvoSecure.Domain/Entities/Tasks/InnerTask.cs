using AdvoSecure.Domain.Entities.Base;
using AdvoSecure.Domain.Entities.Notes;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvoSecure.Domain.Entities.Tasks
{
    [Table("Tasks")]
    public class InnerTask : BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? ProjectedStart { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? DueDate { get; set; }

        public DateTime? ProjectedEnd { get; set; }

        public DateTime? ActualEnd { get; set; }

        public bool IsGroupingTask { get; set; }

        public InnerTask SequentialPredecessor { get; set; }

        public bool Active { get; set; }

        public int CompletePercentage { get; set; }

        public int? ParentId { get; set; }

        public int? TaskTypeId { get; set; }

        public TaskType TaskType { get; set; }

        public IList<TaskAssignedContact> TaskAssignedContacts { get; set; } = new List<TaskAssignedContact>();

        public IList<TaskMatter> TaskMatters { get; set; } = new List<TaskMatter>();

        public IList<NoteTask> NoteTasks { get; set; } = new List<NoteTask>();
    }
}
