using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.Gateway.Dtos
{
    public class DrzavaUpdateDTO
    {
        public Guid DrzavaId { get; set; }
        [Required(ErrorMessage = "Obavezno je uneti naziv drzave.")]
        [StringLength(65, ErrorMessage = "Maximum 65 karaktera prekoračeno")]
        public string DrzavaNaziv { get; set; } = string.Empty;
    }
}
