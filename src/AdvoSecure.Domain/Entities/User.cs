using AdvoSecure.Domain.Entities.Base;

namespace AdvoSecure.Domain.Entities;

public class User : AuditableEntityIncrementalInt
{
    public string AzureIdentityId { get; set; }
    public string AzureEmail { get; set; }
    public string DisplayName { get; set; } = string.Empty;
    public string AzureTenantId { get; set; }
}
