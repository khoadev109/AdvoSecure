using AdvoSecure.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvoSecure.Domain.Entities.TaskType
{
    public class TaskType : BaseEntity
    {
        public string? Title { get; set; }

        public string? Icon { get; set; }
    }
}
