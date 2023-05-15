using System.ComponentModel.DataAnnotations;

namespace AdvoSecure.Domain.Entities.Billings
{
    public class InvoiceTime
    {
        [Key]
        public Guid Id { get; set; }

        public Guid InvoiceId { get; set; }
        
        public Invoice Invoice { get; set; }

        public Guid TimeId { get; set; }

        public Timing.Time Time { get; set; }
        
        public TimeSpan Duration { get; set; }
        
        public decimal PricePerHour { get; set; }

        public string Details { get; set; }
    }
}
