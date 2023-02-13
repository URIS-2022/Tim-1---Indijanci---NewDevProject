using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.KupacAPI.DTOs.FizickoLiceDTOs
{
    /// <summary>
    /// Model za izmenu fizickog lica.
    /// </summary>
    public class FizickoLiceUpdateDto : IValidatableObject
    {
        /// <summary>
        /// ID kupca (strani kljuc).
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti ID kupca.")]
        public Guid KupacId { get; set; }

        /// <summary>
        /// ID fizickog lica.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti ID FL.")]
        public Guid FizickoLiceId { get; set; }

        /// <summary>
        /// Ime fiizckog lica.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti ime FL.")]
        [StringLength(35, ErrorMessage = "Maximum 35 karaktera prekoračeno")]
        public string FizickoLiceIme { get; set; }

        /// <summary>
        /// Prezime fizickog lica.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti prezime FL.")]
        [StringLength(35, ErrorMessage = "Maximum 35 karaktera prekoračeno")]
        public string FizickoLicePrezime { get; set; }

        /// <summary>
        /// Jedinstveni maticni broj gradjana.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti JMBG.")]
        public string JMBG { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (FizickoLiceIme == FizickoLicePrezime)
            {
                yield return new ValidationResult(
                  "Fizicko lice ne sme imati istu vrednost za ime i prezime.",
                  new[] { "FizickoLiceCreateDTO" });

            }
            if (JMBG.Length != 13)
            {
                yield return new ValidationResult(
                 "JMBG mora imati tacno 13 cifara.",
                 new[] { "FizickoLiceCreateDTO" });
            }
        }
    }
}
