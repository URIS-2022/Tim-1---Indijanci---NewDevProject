using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Licitacija.Services.Gateway.Dtos
{
    public class FazaLicitacijeCreateDTO
    {
        [Required(ErrorMessage = "Obavezno je naziv licitacije.")]
        [StringLength(70, ErrorMessage = "Maximum 70 karaktera prekoračeno")]
        public String FazaNaziv { get; set; } = String.Empty;

        public Guid? LicitacijaId { get; set; }
    }
}
