using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.Gateway.Dtos
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

    public enum RoleEnum
    {
        Admin = 0,
        Operater = 1,
        TehnickiSekretar = 2,
        PrvaKomisija = 3,
        SuperUser = 4,
        OperaterNadmetanja = 5,
        Licitant = 6,
        Menadzer = 7
    }
}
