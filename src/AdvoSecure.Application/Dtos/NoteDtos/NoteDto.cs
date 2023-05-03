using AdvoSecure.Domain.Entities.Base;

namespace AdvoSecure.Application.Dtos.Notes
{
    public class NoteDto
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public DateTime? Timestamp { get; set; } = null;
    }
}
