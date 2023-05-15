using AdvoSecure.Application.Dtos.ContactDtos;

namespace AdvoSecure.Application.Dtos.Timing
{
    public class TimeDto
    {
        public Guid Id { get; set; }

        public DateTime Start { get; set; }

        public DateTime? Stop { get; set; }

        public string Details { get; set; }

        public bool Billable { get; set; }

        public int WorkerContactId { get; set; }

        public ContactDto WorkerContact { get; set; }

        public int? TimeCategoryId { get; set; }

        public TimeCategoryDto TimeCategory { get; set; }
    }
}
