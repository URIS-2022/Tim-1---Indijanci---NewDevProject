using Licitacija.Services.ParcelaAPI.Entities;
using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.ParcelaAPI.DTOs.DeoParceleDTOs
{
    /// <summary>
    /// Model za kreiranje dela parcele
    /// </summary>
    public class DeoParceleCreateDTO : IValidatableObject
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
        public Guid? KupacId { get; set; }

        public Parcela? parcela { get; set; }

        public IList<DeoParcele> deloviParcele { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            int zbirPovrsinaDelovaParcele = deloviParcele.Sum(x => x.PovrsinaDelaParcele);

            if (parcela.Povrsina != zbirPovrsinaDelovaParcele)
            {
                yield return new ValidationResult(
                    "Zbir povrsina delova parcele mora biti jednak povrsini cele parcele.",
                    new[] { "DeoParceleCreateDTO" });
            }
        }
    }
}
