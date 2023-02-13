using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Licitacija.Services.Gateway.Dtos
{
    /// <summary>
    /// Model za izmenu kursa.
    /// </summary>
    public class KursUpdateDto
    {
        public Guid KursId { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti datum kursa.")]
        public DateTime DatumKursa { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti valutu.")]
        [StringLength(10, ErrorMessage = "Maximum 10 karaktera prekoračeno")]
        public string Valuta { get; set; } = string.Empty;

        [Required(ErrorMessage = "Obavezno je uneti vrednost kursa.")]
        public decimal Vrednost { get; set; }

    }
}
