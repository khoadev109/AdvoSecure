using AdvoSecure.Domain.Entities.Base;

namespace AdvoSecure.Domain.Entities.Timing
{
    public class TimeCategory : BaseEntity
    {
        public string Title { get; set; }

        public IList<Time> Times { get; set; } = new List<Time>();
    }
}
