using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Licitacija.Services.AdresaAPI.DTOs.Adresa
{
    /// <summary>
    /// Model za kreiranje adrese.
    /// </summary>
    public class AdresaCreateDTO : IValidatableObject
    {
        /// <summary>
        /// Naziv ulice.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti naziv ulice.")]
        [StringLength(65, ErrorMessage = "Maximum {2} characters exceeded")]
        public string Ulica { get; set; } = string.Empty;

        /// <summary>
        /// Broj kuće/stana.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti broj kuce/stana.")]
        [StringLength(15, ErrorMessage = "Maximum {2} characters exceeded")]
        public string Broj { get; set; } = string.Empty;

        /// <summary>
        /// Naziv mesta.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti mesto stanovanja.")]
        [StringLength(65, ErrorMessage = "Maximum {2} characters exceeded")]
        public string Mesto { get; set; } = string.Empty;

        /// <summary>
        /// Poštanski broj mesta.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti postanski broj.")]
        [StringLength(15, ErrorMessage = "Maximum {2} characters exceeded")]
        public string PostanskiBroj { get; set; } = string.Empty;

        /// <summary>
        /// ID države (strani ključ)
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti id drzave.")]
        public Guid DrzavaId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var regexItem = new Regex("^[a-zA-Z0-9 ]*$");

            if (!regexItem.IsMatch(Broj) || !regexItem.IsMatch(PostanskiBroj))
            {
                yield return new ValidationResult(
                  "Nije moguće izmeniti adresu zato sto neki unosi sadrze specijalne karaktere.",
                  new[] { "AdresaCreateDto" });

            }
        }
    }
}
