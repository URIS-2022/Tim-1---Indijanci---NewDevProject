using Licitacija.Services.ParcelaAPI.Entities;
using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.ParcelaAPI.DTOs.DeoParceleDTOs
{
    /// <summary>
    /// Model za kreiranje dela parcele
    /// </summary>
    public class DeoParceleCreateDto : IValidatableObject
    {
        /// <summary>
        /// Povrsina dela parcele
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti povrsinu dela parcele.")]
        public int PovrsinaDelaParcele { get; set; }

        /// <summary>
        /// ID parcele (strani kljuc)
        /// </summary>
        public Guid? ParcelaId { get; set; }

        /// <summary>
        /// ID etape (strani kljuc)
        /// </summary>
        public Guid? EtapaId { get; set; }

        /// <summary>
        /// ID kupca (iz ms Kupac).
        /// </summary>
        public Guid? OtvaranjePonudaId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (PovrsinaDelaParcele <= 0)
            {
                yield return new ValidationResult(
                    "Nije moguce uneti 0 za povrsinu dela parcele.",
                    new[] { "DeoParceleCreateDTO" });
            }
        }
    }
}
