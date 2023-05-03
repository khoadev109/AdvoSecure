using AdvoSecure.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace AdvoSecure.Domain.Entities
{
    public class Language : BaseEntity
    {
        [Required]
        [MaxLength(2)]
        public string? Alpha2 { get; set; }

        [Required]
        [MaxLength(3)]
        public string? Alpha3 { get; set; }

        [Required]
        public string? Title { get; set; }

        public string? TitleEn { get; set; }
        public string? TitleFr { get; set; }
        public string? TitleDe { get; set; }
        public string? TitleNl { get; set; }
        public string? TitleIt { get; set; }
        public string? TitleEs { get; set; }
    }
}
