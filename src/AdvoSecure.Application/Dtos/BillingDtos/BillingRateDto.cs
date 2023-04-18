namespace AdvoSecure.Application.Dtos.BillingDtos
{
    public class BillingRateDto : BaseDto
    {
        public string Title { get; set; }

        public decimal PricePerUnit { get; set; }
    }
}
