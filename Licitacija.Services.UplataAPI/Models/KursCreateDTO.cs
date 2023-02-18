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

            if (!Regex.IsMatch(Valuta, "^[a-zA-Z0-9 ]*$", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
            {
                yield return new ValidationResult(
                  "Nije moguće kreirati kurs zbog neispravne valute.",
                  new[] { "KursCreateDTO" });

            }
        }
    }
}
