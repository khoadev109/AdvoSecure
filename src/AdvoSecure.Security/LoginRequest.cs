namespace AdvoSecure.Security
{
    public record class LoginRequest(string UserName, string Password, string? TenantIdentifier = null);
}
