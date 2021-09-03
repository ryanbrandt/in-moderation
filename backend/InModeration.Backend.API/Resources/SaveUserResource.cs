using System.ComponentModel.DataAnnotations;

namespace InModeration.Backend.API.Resources
{
    public class SaveUserResource
    {
        [Required(ErrorMessage = "Email is required")]
        [MaxLength(200, ErrorMessage = "Max email length is 200")]
        [EmailAddress(ErrorMessage = "Email address must be valid format")]
        public string Email { get; set; }
    }
}
