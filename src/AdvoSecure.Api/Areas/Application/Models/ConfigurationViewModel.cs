namespace AdvoSecure.Api.Areas.Application.Models;

public class ConfigurationViewModel
{
    public string TenantId { get; set; }
    public string Scope { get; set; }

    public string ClientId { get; set; }
    public string RedirectUrl { get; set; }

}
