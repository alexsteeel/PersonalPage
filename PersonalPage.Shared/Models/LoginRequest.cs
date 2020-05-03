using System.ComponentModel.DataAnnotations;

namespace PersonalPage.Shared.Models
{
    public class LoginRequest
    {

        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }
    }
}
