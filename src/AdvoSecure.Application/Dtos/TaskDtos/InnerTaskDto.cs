using AdvoSecure.Domain.Entities.Tasks;

namespace AdvoSecure.Application.Dtos.TaskDtos
{
    public class InnerTaskDto
    {
        public long Id { get; set; }

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
    }
}
