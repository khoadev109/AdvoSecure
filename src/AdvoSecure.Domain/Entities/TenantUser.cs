using AdvoSecure.Domain.Entities.Base;

namespace AdvoSecure.Domain.Entities
{
    public class TenantUser : BaseEntity
    {
        public Guid UserIdentifier { get; set; }

        public string Name { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public string Email { get; set; }

        public IList<TenantDirectory> TenantDirectories { get; set; } = new List<TenantDirectory>();
    }
}
