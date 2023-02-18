using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.LicitacijaAPI.DTOs.FazaLicitacijeDTOs
{
    /// <summary>
    /// Model za izmenu faze licitacije.
    /// </summary>
    public class FazaLicitacijeUpdateDto
    {
        /// <summary>
        /// ID faze licitacije
        /// </summary>
        public Guid FazaId { get; set; }

        /// <summary>
        /// Naziv faze Licitacije
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti naziv faze licitacije.")]
        public String FazaNaziv { get; set; } = String.Empty;


        /// <summary>
        /// ID Licitacije
        /// </summary>
        public Guid? LicitacijaId { get; set; }
    }
}
