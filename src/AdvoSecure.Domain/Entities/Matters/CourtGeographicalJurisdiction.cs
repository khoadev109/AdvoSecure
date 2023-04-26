using AdvoSecure.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvoSecure.Domain.Entities.Matters
{
    [Table("CourtGeographicalJurisdictions")]
    public class CourtGeographicalJurisdiction : BaseEntity
    {
        public string Title { get; set; }

        public IList<Matter> Matters { get; set; } = new List<Matter>();
    }
}
