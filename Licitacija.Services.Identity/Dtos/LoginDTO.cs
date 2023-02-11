using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.Identity.Dtos
{
    public class LoginDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
