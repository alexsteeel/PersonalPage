using System.ComponentModel.DataAnnotations;

namespace PersonalPage.Shared.Models
{
    public class LoginRequest
    {
        [Required]
        [StringLength(20)]
        public string UserName { get; set; }

        [Required]
        [StringLength(15)]
        public string Password { get; set; }
    }
}
