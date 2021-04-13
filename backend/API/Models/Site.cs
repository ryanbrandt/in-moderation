using System;
using System.ComponentModel.DataAnnotations;

namespace InModeration.Backend.API.Models
{
    public class Site
    {
        [Key]
        public int Id { get; private set;  }

        [Required]
        [MaxLength(200)]
        public string Domain { get; set; }

        public DateTime Created { get; private set; }
    }
}
