using AdvoSecure.Domain.Entities.Base;
using AdvoSecure.Domain.Entities.Contacts;
using AdvoSecure.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvoSecure.Domain.Entities.Tasks
{
    [Table("TaskAssignedContacts")]
    public class TaskAssignedContact : BaseGuidEntity
    {
        public int TaskId { get; set; }

        public InnerTask Task { get; set; }


        public int ContactId { get; set; }

        public Contact Contact { get; set; }


        public AssignmentType AssignmentType { get; set; }
    }
}
