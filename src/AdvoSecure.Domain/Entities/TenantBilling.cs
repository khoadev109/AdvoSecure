using AdvoSecure.Domain.Entities.Base;

namespace AdvoSecure.Domain.Entities
{
    public class TenantBilling : BaseEntity
    {
        public string FirmName { get; set; }
        public string FirmAddress { get; set; }
        public string FirmAddress2 { get; set; }
        public string FirmCity { get; set; }
        public string FirmState { get; set; }
        public string FirmZip { get; set; }
        public string FirmCountry { get; set; }
        public string FirmPhone { get; set; }
        public string FirmWeb { get; set; }
        public string FirmVATid { get; set; }
        public string FirmBankAccount { get; set; }
        public string FirmBankBIC { get; set; }
        public string FirmBankName { get; set; }
        public int TenantId { get; set; }
        public TenantSetting TenantSetting { get; set; }
    }
}
