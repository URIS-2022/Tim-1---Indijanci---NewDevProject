using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Licitacija.Services.AdresaAPI.DTOs.Adresa
{
    /// <summary>
    /// Model za kreiranje adrese.
    /// </summary>
    public class AdresaCreateDto : IValidatableObject
    {
        /// <summary>
        /// Naziv ulice.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti naziv ulice.")]
        [StringLength(65, ErrorMessage = "Maximum 65 karaktera prekoračeno")]
        public string Ulica { get; set; } = string.Empty;

        /// <summary>
        /// Broj kuće/stana.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti broj kuce/stana.")]
        [StringLength(15, ErrorMessage = "Maximum 15 karaktera prekoračeno")]
        public string Broj { get; set; } = string.Empty;

        /// <summary>
        /// Naziv mesta.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti mesto stanovanja.")]
        [StringLength(65, ErrorMessage = "Maximum 65 karaktera prekoračeno")]
        public string Mesto { get; set; } = string.Empty;

        /// <summary>
        /// Poštanski broj mesta.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti postanski broj.")]
        [StringLength(15, ErrorMessage = "Maximum 15 karaktera prekoračeno")]
        public string PostanskiBroj { get; set; } = string.Empty;

        /// <summary>
        /// ID države (strani ključ)
        /// </summary>
        public Guid? DrzavaId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var regexItem = new Regex("^[a-zA-Z0-9 ]*$", RegexOptions.None, TimeSpan.FromMilliseconds(100));

            if (!regexItem.IsMatch(Broj) || !regexItem.IsMatch(PostanskiBroj))
            {

                yield return new ValidationResult(
                  "Nije moguće kreirati adresu zato sto neki unosi sadrže specijalne karaktere.",
                  new[] { "AdresaCreateDTO" });

            }

            AppDomain.CurrentDomain.SetData("REGEX_DEFAULT_MATCH_TIMEOUT", TimeSpan.FromMilliseconds(100));
        }
    }
}
