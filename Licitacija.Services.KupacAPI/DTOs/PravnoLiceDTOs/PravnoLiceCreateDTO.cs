using Licitacija.Services.KupacAPI.Entities;
using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.KupacAPI.DTOs.PravnoLiceDTOs
{
    /// <summary>
    /// Model za kreiranje pravnog lica.
    /// </summary>
    public class PravnoLiceCreateDto : IValidatableObject
    {
        /// <summary>
        /// ID kupca (strani kljuc).
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti ID kupca.")]
        public Guid KupacId { get; set; }

        /// <summary>
        /// Naziv pravnog lica.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti naziv PL.")]
        [StringLength(35, ErrorMessage = "Maximum 35 karaktera prekoračeno")]
        public string PravnoLiceNazv { get; set; }

        /// <summary>
        /// Maticni broj pravnog lica.
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti maticni broj.")]
        public string MaticniBroj { get; set; }

        /// <summary>
        /// Broj faksa.
        /// </summary>
        public string? Faks { get; set; }

        /// <summary>
        /// Kontakt osoba ID (strani kljuc).
        /// </summary>
        public Guid? KontaktOsobaId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (MaticniBroj.Length != 8)
            {
                yield return new ValidationResult(
                 "Maticni broj mora imati tacno 8 cifara.",
                 new[] { "PravnoLiceCreateDTO" });
            }
        }
    }
}
