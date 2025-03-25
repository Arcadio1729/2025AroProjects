using aroshopapi.Models;
using System.ComponentModel.DataAnnotations;

namespace aroshopapi.Dtos
{
    public class UserDto
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
