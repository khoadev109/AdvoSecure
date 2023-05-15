using AdvoSecure.Domain.Entities.Base;
using AdvoSecure.Domain.Entities.Matters;

namespace AdvoSecure.Domain.Entities.Billings
{
    public class Fee : BaseGuidEntity
    {
        public DateTime Incurred { get; set; }

        public decimal Amount { get; set; }
        
        public string Details { get; set; }

        public IList<InvoiceFee> InvoiceFees { get; set; } = new List<InvoiceFee>();

        public IList<Matter> Matters { get; set; } = new List<Matter>();
    }
}
