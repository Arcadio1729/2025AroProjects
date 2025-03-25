using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace aroshopapi.Models
{
    [Index(nameof(Name), IsUnique = true)] // Makes the Username field unique
    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
        [Key]
        public string Id { get; set; }
        
        [Required]
        [StringLength(50,ErrorMessage = "User name must be between 3 and 50", MinimumLength = 3)]
        public string? Name { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [ForeignKey(nameof(RoleId))]
        public virtual Role Role { get; set; }
        public string RoleId { get; set; } 
    }
}