using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace aroshopapi.Dtos
{
    public class CreateUserDto
    {

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]

        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        [AllowedValues("user")]
        public string RoleName { get; set; }
    }
}
