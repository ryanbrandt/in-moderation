using System;
using System.ComponentModel.DataAnnotations;

namespace InModeration.Backend.API.Models
{
    public class SiteRule
    {
        public int UserId { get; set;  }

        public User User { get; private set; }

        public int SiteId { get; set; }

        public Site Site { get; private set; }

        [Required]
        public int Time { get; set; }

        [Required]
        public int Points { get; set; }

        public DateTime Created { get; private set; }

        public DateTime Modified { get; set; }
    }
}
