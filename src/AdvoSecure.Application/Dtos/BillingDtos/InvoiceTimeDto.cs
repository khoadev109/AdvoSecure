using AdvoSecure.Application.Dtos.Timing;

namespace AdvoSecure.Application.Dtos.BillingDtos
{
    public class InvoiceTimeDto
    {
        public Guid Id { get; set; }

        public Guid InvoiceId { get; set; }

        public InvoiceDto Invoice { get; set; }

        public Guid TimeId { get; set; }

        public TimeDto Time { get; set; }

        public TimeSpan Duration { get; set; }

        public decimal PricePerHour { get; set; }

        public string Details { get; set; }
    }
}
