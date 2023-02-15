using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.Gateway.Dtos
{

    public class PredradnjeNadmetanjaCreateDto
    {
        [Required(ErrorMessage = "Obavezno je uneti naziv predradnje.")]
        [StringLength(65, ErrorMessage = "Maximum 65 karaktera prekoračeno")]
        public string PredradnjeNadmetanjaNaziv { get; set; } = String.Empty;

        [Required(ErrorMessage = "Obavezno je uneti id predradnje.")]
        public Guid FazaId { get; set; }
    }
}
