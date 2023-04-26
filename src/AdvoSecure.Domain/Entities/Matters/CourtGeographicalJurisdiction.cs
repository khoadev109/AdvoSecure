using AdvoSecure.Domain.Entities.Base;

namespace AdvoSecure.Domain.Entities.Matters
{
    public class CourtGeographicalJurisdiction : BaseEntity
    {
        public string Title { get; set; }

        public IList<Matter> Matters { get; set; } = new List<Matter>();
    }
}
