using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvoSecure.Application.Dtos.ContactDtos
{
    public class ContactTitleDTO : BaseDto
    {
        public string Title { get; set; }

        public string Profession { get; set; }

        public string Saluation { get; set; }
    }
}
