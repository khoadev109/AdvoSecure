using AdvoSecure.Domain.Entities.Base;
using AdvoSecure.Domain.Entities.Matters;

namespace AdvoSecure.Domain.Entities.Tasks
{
    public class TaskMatter : AuditableEntity<Guid>
    {
        public int TaskId { get; set; }

        public Task Task { get; set; }


        public Guid MatterId { get; set; }

        public Matter Matter { get; set; }
    }
}
