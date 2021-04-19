using System;
using System.ComponentModel.DataAnnotations;

namespace InModeration.Backend.API.Models
{
    public class Site
    {
        [Key]
        public int Id { get; private set;  }

        [Required(ErrorMessage = "Domain is required")]
        [MaxLength(200, ErrorMessage = "Max domain length is 200")]
        [Url(ErrorMessage = "Domain must be a URL")]
        public string Domain { get; set; }

        public DateTime Created { get; private set; }
    }
}
