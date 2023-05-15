using AdvoSecure.Application.Dtos.ContactDtos;
using AdvoSecure.Application.Dtos.MatterDtos;

namespace AdvoSecure.Application.Dtos.BillingDtos
{
    public class InvoiceDto
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public DateTime Due { get; set; }

        public decimal Subtotal { get; set; }

        public decimal TaxAmount { get; set; }

        public decimal Total { get; set; }

        public string ExternalInvoiceId { get; set; }

        public string BillTo_NameLine1 { get; set; }

        public string BillTo_NameLine2 { get; set; }

        public string BillTo_AddressLine1 { get; set; }

        public string BillTo_AddressLine2 { get; set; }

        public string BillTo_City { get; set; }

        public string BillTo_State { get; set; }

        public string BillTo_Zip { get; set; }

        public int BillToId { get; set; }

        public ContactDto BillTo { get; set; }

        public int? BillingGroupId { get; set; }

        public BillingGroupDto BillingGroup { get; set; }

        public Guid? MatterId { get; set; }

        public MatterDto Matter { get; set; }
    }
}
