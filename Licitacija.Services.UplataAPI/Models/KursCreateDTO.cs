using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Licitacija.Services.UplataAPI.Models
{
    /// <summary>
    /// Model za kreiranje kursa.
    /// </summary>
    public class KursCreateDto : IValidatableObject
    {
        /// <summary>
        /// Datum kursa.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti datum kursa.")]
        public DateTime DatumKursa { get; set; }

        /// <summary>
        /// Valuta kursa.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti valutu.")]
        [StringLength(10, ErrorMessage = "Maximum 10 karaktera prekoračeno")]
        public string Valuta { get; set; } = string.Empty;

        /// <summary>
        /// Vrednost kursa.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti vrednost kursa.")]
        public decimal Vrednost { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var regexItem = new Regex("^[a-zA-Z0-9 ]*$");

            if (!regexItem.IsMatch(Valuta))
            {
                yield return new ValidationResult(
                  "Nije moguće izmeniti kurs zbog neispravne valute.",
                  new[] { "KursUpdateDTO" });

            }
        }
    }
}
