using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.Gateway.Dtos
{
    public class LicitacijaUpdateDTO
    {
        public Guid LicitacijaId { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti broj licitacije.")]
        public int Broj { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti godinu licitacije.")]
        public int Godina { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti datum licitacije.")]
        public DateTime Datum { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti ogranicenje licitacije.")]
        public int Ogranicenje { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti korak cene licitacije.")]
        public int KorakCene { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti rok za prijavu licitacije.")]
        public DateTime RokZaPrijave { get; set; }
    }
}
