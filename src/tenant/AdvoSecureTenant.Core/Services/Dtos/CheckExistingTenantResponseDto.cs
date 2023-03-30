namespace AdvoSecureTenant.Core.Services.Dtos
{
    public class CheckExistingTenantResponseDto
    {
        public string AzureTenantId { get; set; }
        public bool IsTenantAdmin { get; set; }
        public bool Result { get; set; }
    }
}
