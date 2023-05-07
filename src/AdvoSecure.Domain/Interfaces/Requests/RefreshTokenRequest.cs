namespace AdvoSecure.Domain.Interfaces.Requests
{
    public class RefreshTokenRequest
    {
        public int Id { get; set; }

        public string Token { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public DateTime Expires { get; set; }

        public Guid UserIdentifier { get; set; }

        public Guid TenantIdentifier { get; set; }
    }
}
