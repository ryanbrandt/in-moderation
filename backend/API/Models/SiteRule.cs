using System;
using System.Runtime;
using System.ComponentModel.DataAnnotations;

namespace InModeration.Backend.API.Models
{
    public class SiteRule
    {
        [Required(ErrorMessage = "User Id is required")]
        public int UserId { get; set;  }

# nullable enable
        public User? User { get; set; }
# nullable disable

        [Required(ErrorMessage = "Site Id is required")]
        public int SiteId { get; set; }

# nullable enable
        public Site? Site { get; set; }
# nullable disable

        [Required(ErrorMessage = "Time is required")]
        public int Time { get; set; }

        [Required(ErrorMessage = "Points is required")]
        public int Points { get; set; }

        public DateTime Created { get; private set; }

        public DateTime Modified { get; set; }
    }
}
