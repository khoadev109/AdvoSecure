namespace AdvoSecure.Application.Dtos
{
    public class UserDto : BaseDto
    {
        public string AzureIdentityId { get; set; }
        public string AzureEmail { get; set; }
        public string DisplayName { get; set; } = string.Empty;
        public string AzureTenantId { get; set; }
    }
}
