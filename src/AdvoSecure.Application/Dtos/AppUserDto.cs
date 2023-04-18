using AdvoSecure.Security;
using System.Security.Claims;

namespace AdvoSecure.Application.Dtos
{
    public class AppUserProfileRequestDto
    {
        public ClaimsPrincipal User { get; set; }

        public string DisplayName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string UserIdentifier { get; set; }
    }
}
