using System.ComponentModel.DataAnnotations;

namespace aroshopapi.Dtos
{
    public class UpdateUserDto
    {
        [Required]
        [StringLength(50, ErrorMessage = "User name must be between 3 and 50", MinimumLength = 3)]
        public string? Name { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

    }
}
