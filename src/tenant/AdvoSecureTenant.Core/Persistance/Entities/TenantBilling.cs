namespace AdvoSecureTenant.Core.Persistance.Entities
{
    public class TenantBilling : BaseEntity
    {
        public string BillingFirmName { get; set; }
        public string BillingFirmAddress { get; set; }
        public string BillingFirmAddress2 { get; set; }
        public string BillingFirmCity { get; set; }
        public string BillingFirmState { get; set; }
        public string BillingFirmZip { get; set; }
        public string BillingFirmCountry { get; set; }
        public string BillingFirmPhone { get; set; }
        public string BillingFirmWeb { get; set; }
        public string BillingFirmVATid { get; set; }
        public string BillingFirmBankAccount { get; set; }
        public string BillingFirmBankBIC { get; set; }
        public string BillingFirmBankName { get; set; }
    }
}
