namespace AdvoSecure.Domain.Entities.Tasks
{
    public class TaskTag : Tagging.TagBase
    {
        public int TaskId { get; set; }

        public InnerTask Task { get; set; }
    }
}
