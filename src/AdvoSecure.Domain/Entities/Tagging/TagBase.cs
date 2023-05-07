using AdvoSecure.Domain.Entities.Base;
using AdvoSecure.Domain.Entities.Tasks;

namespace AdvoSecure.Domain.Entities.Tagging
{
    public class TagBase : BaseGuidEntity
    {
        public string Tag { get; set; }

        public int? TagCategoryId { get; set; }

        public TagCategory TagCategory { get; set; }

        public IList<InnerTask> Tasks { get; set; } = new List<InnerTask>();
    }
}
