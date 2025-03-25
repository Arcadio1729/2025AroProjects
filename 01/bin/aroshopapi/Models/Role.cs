using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aroshopapi.Models
{
    public class Role
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public virtual List<User> Users { get; set; }
    }
}
