using AdvoSecure.Domain.Entities.Base;
using AdvoSecure.Domain.Entities.Matters;
using AdvoSecure.Domain.Entities.Notes;
using AdvoSecure.Domain.Entities.Tagging;
using AdvoSecure.Domain.Entities.Timing;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvoSecure.Domain.Entities.Tasks
{
    [Table("Tasks")]
    public class InnerTask : BaseLongEntity
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

        //public IList<TaskMatter> TaskMatters { get; set; } = new List<TaskMatter>();

        public IList<Matter> Matters { get; set; } = new List<Matter>();

        public IList<Time> Times { get; set; } = new List<Time>();

        public IList<TagBase> Tags { get; set; } = new List<TagBase>();

        public IList<Note> Notes { get; set; } = new List<Note>();
    }
}
