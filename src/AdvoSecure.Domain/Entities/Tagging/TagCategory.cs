using AdvoSecure.Domain.Entities.Base;

namespace AdvoSecure.Domain.Entities.Tagging
{
    public class TagCategory : BaseEntity
    {
        public string Name { get; set; }

        public IList<TagBase> TagBases { get; set; } = new List<TagBase>();
    }
}
