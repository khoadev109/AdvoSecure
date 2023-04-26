using AdvoSecure.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvoSecure.Domain.Entities.Matters
{
    [Table("MatterAreas")]
    public class MatterArea : BaseEntity
    {
        public int AreaGroup { get; set; }

        public string AreaCode { get; set; }

        public string Title { get; set; }

        public IList<Matter> Matters { get; set; } = new List<Matter>();
    }
}
