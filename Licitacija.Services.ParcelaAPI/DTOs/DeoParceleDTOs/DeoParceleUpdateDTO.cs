using Licitacija.Services.ParcelaAPI.Entities;
using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.ParcelaAPI.DTOs.DeoParceleDTOs
{
    /// <summary>
    /// Model za azuriranje dela parcele
    /// </summary>
    public class DeoParceleUpdateDto : IValidatableObject
    {
        /// <summary>
        /// ID dela parcele
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti ID dela parcele.")]
        public Guid DeoParceleId { get; set; }

        /// <summary>
        /// Povrsina dela parcele
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti povrsinu dela parcele.")]
        public int PovrsinaDelaParcele { get; set; }

        /// <summary>
        /// ID parcele (strani kljuc)
        /// </summary>
        public Guid ParcelaId { get; set; }

        /// <summary>
        /// ID etapa (strani kljuc)
        /// </summary>
        public Guid EtapaId { get; set; }

        /// <summary>
        /// ID otvaranja ponude (strani kljuc)
        /// </summary>
        public Guid OtvaranjePonudaId { get; set; }

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
