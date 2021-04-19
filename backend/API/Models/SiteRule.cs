using System;
using System.ComponentModel.DataAnnotations;

namespace InModeration.Backend.API.Models
{
    public class SiteRule
    {
        [Required(ErrorMessage = "User Id is required")]
        public int UserId { get; set;  }

        public User User { get; private set; }

        [Required(ErrorMessage = "Site Id is required")]
        public int SiteId { get; set; }

        public Site Site { get; private set; }

        [Required(ErrorMessage = "Time is required")]
        public int Time { get; set; }

        [Required(ErrorMessage = "Points is required")]
        public int Points { get; set; }

        public DateTime Created { get; private set; }

        public DateTime Modified { get; set; }
    }
}
