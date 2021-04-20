using System;
using System.ComponentModel.DataAnnotations;

namespace InModeration.Backend.API.Models
{
    public class User
    {
        public int Id { get; private set; }

        [Required(ErrorMessage = "Email is required")]
        [MaxLength(200, ErrorMessage = "Max email length is 200")]
        [EmailAddress(ErrorMessage = "Email address must be valid format")]
        public string Email { get; set; }

        public DateTime Created { get; private set; }

        public DateTime Modified { get; set; }
    }
}
