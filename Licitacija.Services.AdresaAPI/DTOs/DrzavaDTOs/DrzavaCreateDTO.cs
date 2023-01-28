using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Licitacija.Services.AdresaAPI.DTOs.Drzava
{
    /// <summary>
    /// Model za kreiranje države.
    /// </summary>
    public class DrzavaCreateDTO : IValidatableObject
    {
        /// <summary>
        /// Naziv države.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti naziv drzave.")]
        [StringLength(65, ErrorMessage = "Maximum {2} characters exceeded")]
        public string DrzavaNaziv { get; set; } = string.Empty;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var regexItem = new Regex("^[a-zA-Z0-9 ]*$");

            if (!regexItem.IsMatch(DrzavaNaziv))
            {
                yield return new ValidationResult(
                  "Nije moguće izmeniti drzavu zato sto unos sadrzi specijalne karaktere.",
                  new[] { "DrzavaCreateDto" });

            }
        }
    }
}
