using AdvoSecure.Domain.Entities.Base;
using AdvoSecure.Domain.Entities.Contacts;
using AdvoSecure.Domain.Enums;

namespace AdvoSecure.Domain.Entities.Tasks
{
    public class TaskAssignedContact : AuditableEntity<Guid>
    {
        public int TaskId { get; set; }

        public Task Task { get; set; }


        public int ContactId { get; set; }

        public Contact Contact { get; set; }


        public AssignmentType AssignmentType { get; set; }
    }
}
