namespace AdvoSecure.Security
{
    public class UserClaims
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Email { get; set; }

        public IEnumerable<string> Roles { get; set; } = new List<string>();

        public string UserIdentifier { get; set; }

        public string? TenantIdentifier { get; set; }

        public string TenantAdminIdentifier { get; set; }
    }
}
