using AdvoSecure.Domain.Entities.Base;

namespace AdvoSecure.Domain.Entities
{
    public class Case : AuditableEntityIncrementalInt
    {
        public string Name { get; set; }
    }
}
