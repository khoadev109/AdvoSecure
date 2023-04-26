using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvoSecure.Application.Dtos
{
    public class LanguageDto
    {
        public int Id { get; set; }

        public string Alpha2 { get; set; }
       
        public string Alpha3 { get; set; }
       
        public string Title { get; set; }

        public string TitleEn { get; set; }
        public string TitleFr { get; set; }
        public string TitleDe { get; set; }
        public string TitleNl { get; set; }
        public string TitleIt { get; set; }
        public string TitleEs { get; set; }
    }
}
