namespace AdvoSecure.Security
{
    public class RefreshTokenRequest
    {
        public string? AccessToken { get; set; }

        public string? RefreshToken { get; set; }

        public string? UserIdentifier { get; set; }

        public string? TenantIdentifier { get; set; }
    }
}
