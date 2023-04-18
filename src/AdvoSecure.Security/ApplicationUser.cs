using Microsoft.AspNetCore.Identity;

namespace AdvoSecure.Security
{
    public class ApplicationUser : IdentityUser
    {
        public Guid UserIdentifier { get; set; }

        public string DisplayName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
