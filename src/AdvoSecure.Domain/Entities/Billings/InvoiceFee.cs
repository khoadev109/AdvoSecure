using System.ComponentModel.DataAnnotations;

namespace AdvoSecure.Domain.Entities.Billings
{
    public class InvoiceFee
    {
        [Key]
        public Guid Id { get; set; }

        public Guid InvoiceId { get; set; }

        public Invoice Invoice { get; set; }

        public Guid FeeId { get; set; }

        public Fee Fee { get; set; }
        
        public decimal Amount { get; set; }
        
        public decimal TaxAmount { get; set; }
        
        public string Details { get; set; }
    }
}
