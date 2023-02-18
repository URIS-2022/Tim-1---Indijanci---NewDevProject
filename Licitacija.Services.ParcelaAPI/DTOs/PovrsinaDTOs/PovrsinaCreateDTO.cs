using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.ParcelaAPI.DTOs.PovrsinaDTOs
{
    /// <summary>
    /// Model za kreiranje povrsine
    /// </summary>
    public class PovrsinaCreateDto
    {
        /// <summary>
        /// Povrsina zasticene zone
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti povrsinu zasticene zone.")]
        public int PovrsinaZZone { get; set; }

        /// <summary>
        /// ID parcele (strani kljuc).
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti ID parcele.")]
        public Guid ParcelaId { get; set; }

        /// <summary>
        /// ID zasticene zone (strani kljuc).
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti ID zasticene zone.")]
        public Guid ZZonaId { get; set; }
    }
}
