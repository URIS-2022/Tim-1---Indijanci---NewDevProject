using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.Gateway.Dtos
{

    public class FazaLicitacijeUpdateDTO
    {
        public Guid FazaId { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti naziv faze licitacije.")]
        public String FazaNaziv { get; set; } = String.Empty;

        public Guid? LicitacijaId { get; set; }
    }
}
