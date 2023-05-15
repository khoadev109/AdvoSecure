namespace AdvoSecure.Application.Dtos.BillingDtos
{
    public class InvoiceFeeDto
    {
        public Guid Id { get; set; }

        public Guid InvoiceId { get; set; }

        public InvoiceDto Invoice { get; set; }

        public Guid FeeId { get; set; }

        public FeeDto Fee { get; set; }

        public decimal Amount { get; set; }

        public decimal TaxAmount { get; set; }

        public string Details { get; set; }
    }
}
