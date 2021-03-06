﻿using System.ComponentModel.DataAnnotations;

namespace PersonalPage.Shared.Models
{
    public class RegisterRequest
    {
        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(25)]
        public string UserName { get; set; }

        [Required]
        [StringLength(20)]
        public string Password { get; set; }

        [Required]
        [StringLength(20)]
        public string ConfirmPassword { get; set; }
    }
}
