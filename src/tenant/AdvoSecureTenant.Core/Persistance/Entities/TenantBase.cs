using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvoSecureTenant.Core.Persistance.Entities
{
    public class TenantBase : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Key { get; set; }
    }
}
