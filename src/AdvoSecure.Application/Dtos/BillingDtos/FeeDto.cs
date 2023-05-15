namespace AdvoSecure.Application.Dtos.BillingDtos
{
    public class FeeDto
    {
        public Guid Id { get; set; }

        public DateTime Incurred { get; set; }

        public decimal Amount { get; set; }

        public string Details { get; set; }
    }
}
