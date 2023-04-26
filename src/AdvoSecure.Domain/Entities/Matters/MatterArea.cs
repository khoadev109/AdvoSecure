using AdvoSecure.Domain.Entities.Base;

namespace AdvoSecure.Domain.Entities.Matters
{
    public class MatterArea : BaseEntity
    {
        public int AreaGroup { get; set; }

        public string AreaCode { get; set; }

        public string Title { get; set; }

        public IList<Matter> Matters { get; set; } = new List<Matter>();
    }
}
