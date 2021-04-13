using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace InModeration.Backend.API.Models
{
    public class User
    {
        public int Id { get; private set; }

        [Required]
        [MaxLength(200)]
        public string Email { get; set; }

        public DateTime Created { get; private set; }

        public DateTime Modified { get; set; }
    }
}
