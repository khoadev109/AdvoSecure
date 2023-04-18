using System.ComponentModel.DataAnnotations;

namespace AdvoSecure.Security
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string ReturnUrl { get; set; }
    }
}
