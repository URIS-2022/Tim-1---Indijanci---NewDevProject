using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.ParcelaAPI.DTOs.PovrsinaDTOs
{
    /// <summary>
    /// Model za izmenu povrsine
    /// </summary>
    public class PovrsinaUpdateDTO
    {
        /// <summary>
        /// Povrsina zasticene zone
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti povrsinu zasticene zone.")]
        public int PovrsinaZZone { get; set; }

        /// <summary>
        /// ID parcele (strani kljuc).
        /// </summary>
        public Guid? ParcelaId { get; set; }

        /// <summary>
        /// ID zasticene zone (strani kljuc).
        /// </summary>
        public Guid? ZZonaId { get; set; }
    }
}
