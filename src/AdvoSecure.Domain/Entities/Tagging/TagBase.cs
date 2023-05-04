using AdvoSecure.Domain.Entities.Base;

namespace AdvoSecure.Domain.Entities.Tagging
{
    public class TagBase : BaseGuidEntity
    {
        public int? TagCategoryId { get; set; }

        public TagCategory TagCategory { get; set; }

        public string Tag { get; set; }
    }
}
