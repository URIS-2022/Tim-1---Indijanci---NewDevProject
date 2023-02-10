using Licitacija.Services.Identity.Models;
using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.Identity.Dtos
{
    public class RegisterDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }
        public RoleEnum RoleName { get; set; }
    }
}
