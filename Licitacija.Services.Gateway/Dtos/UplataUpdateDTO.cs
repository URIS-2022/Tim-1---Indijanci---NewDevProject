using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Licitacija.Services.Gateway.Dtos
{
    public class UplataUpdateDto
    {
        public Guid UplataId { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti broj računa.")]
        [StringLength(18, ErrorMessage = "Maximum 18 karaktera prekoračeno")]
        public string BrojRacuna { get; set; } = string.Empty;

        [Required(ErrorMessage = "Obavezno poziv na broj.")]
        [StringLength(17, ErrorMessage = "Maximum 17 karaktera prekoračeno")]
        public string PozivNaBroj { get; set; } = string.Empty;

        [Required(ErrorMessage = "Obavezno je uneti iznos.")]
        public decimal Iznos { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti postanski broj.")]
        [StringLength(100, ErrorMessage = "Maximum 100 karaktera prekoračeno")]
        public string SvrhaUplate { get; set; } = string.Empty;

        [Required(ErrorMessage = "Obavezno je uneti datum uplate.")]
        public DateTime DatumUplate { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti id kupca.")]
        public Guid KupacId { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti id kursa.")]
        public Guid KursId { get; set; }

    }
}
