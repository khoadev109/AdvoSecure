﻿using AdvoSecure.Domain.Entities.Base;

namespace AdvoSecure.Domain.Entities.Tasks
{
    public class Task : BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? ProjectedStart { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? DueDate { get; set; }

        public DateTime? ProjectedEnd { get; set; }

        public DateTime? ActualEnd { get; set; }

        public bool IsGroupingTask { get; set; }

        public Task SequentialPredecessor { get; set; }

        public bool Active { get; set; }

        public int CompletePercentage { get; set; }

        public int? ParentId { get; set; }

        public int? TaskTypeId { get; set; }

        public TaskType TaskType { get; set; }

        public IList<TaskAssignedContact> TaskAssignedContacts { get; set; } = new List<TaskAssignedContact>();

        public IList<TaskMatter> TaskMatters { get; set; } = new List<TaskMatter>();
    }
}
