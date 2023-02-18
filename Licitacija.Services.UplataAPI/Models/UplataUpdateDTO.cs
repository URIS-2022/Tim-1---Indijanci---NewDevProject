using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Licitacija.Services.UplataAPI.Models
{
    /// <summary>
    /// Model za izmenu uplate.
    /// </summary>
    public class UplataUpdateDto : IValidatableObject
    {
        /// <summary>
        /// ID uplate.
        /// </summary>
        public Guid UplataId { get; set; }

        /// <summary>
        /// Broj računa uplate.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti broj računa.")]
        [StringLength(18, ErrorMessage = "Maximum 18 karaktera prekoračeno")]
        public string BrojRacuna { get; set; } = string.Empty;

        /// <summary>
        /// Poziv na broj uplate.
        /// </summary>
        [Required(ErrorMessage = "Obavezno poziv na broj.")]
        [StringLength(17, ErrorMessage = "Maximum 17 karaktera prekoračeno")]
        public string PozivNaBroj { get; set; } = string.Empty;

        /// <summary>
        /// Iznos uplate.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti iznos.")]
        public decimal Iznos { get; set; }

        /// <summary>
        /// Svrha uplate.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti postanski broj.")]
        [StringLength(100, ErrorMessage = "Maximum 100 karaktera prekoračeno")]
        public string SvrhaUplate { get; set; } = string.Empty;

        /// <summary>
        /// Datum uplate.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti datum uplate.")]
        public DateTime DatumUplate { get; set; }

        /// <summary>
        /// ID kupca.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti id kupca.")]
        public Guid KupacId { get; set; }

        /// <summary>
        /// ID kursa.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti id kursa.")]
        public Guid KursId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!Regex.IsMatch(BrojRacuna, "^[a-zA-Z0-9 ]*$", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)) ||
                !Regex.IsMatch(PozivNaBroj, "^[a-zA-Z0-9 ]*$", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
            {
                yield return new ValidationResult(
                  "Nije moguće izmeniti uplatu zato sto neki unosi sadrže specijalne karaktere.",
                  new[] { "UplataUpdateDTO" });

            }
        }
    }
}
