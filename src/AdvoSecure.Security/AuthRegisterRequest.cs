namespace AdvoSecure.Security
{
    public class AuthRegisterRequest
    {
        public string Email { get; set; }

        public string DisplayName { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string? TenantIdentifier { get; set; } = string.Empty;

        public Guid TenantAdminIdentifier { get; set; }

        public bool? SetAsAdmin { get; set; }
    }
}
