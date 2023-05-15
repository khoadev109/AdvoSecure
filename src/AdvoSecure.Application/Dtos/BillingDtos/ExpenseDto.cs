namespace AdvoSecure.Application.Dtos.BillingDtos
{
    public class ExpenseDto
    {

        public Guid Id { get; set; }

        public DateTime Incurred { get; set; }

        public DateTime? Paid { get; set; }

        public string Vendor { get; set; }

        public decimal Amount { get; set; }

        public string Details { get; set; }
    }
}
