namespace AdvoSecure.Application.Dtos.BillingDtos
{
    public class BillingGroupDto : BaseDto
    {
        public string Title { get; set; }

        public DateTime? LastRun { get; set; }

        public DateTime NextRun { get; set; }

        public decimal Amount { get; set; }

        public int BillToContactId { get; set; }
    }
}
