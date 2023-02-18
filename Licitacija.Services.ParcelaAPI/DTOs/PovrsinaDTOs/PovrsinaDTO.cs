using Licitacija.Services.ParcelaAPI.DTOs.ParcelaDTOs;
using Licitacija.Services.ParcelaAPI.DTOs.ZasticenaZonaDTOs;

namespace Licitacija.Services.ParcelaAPI.DTOs.PovrsinaDTOs
{
    /// <summary>
    /// Model za prikaz povrsine
    /// </summary>
    public class PovrsinaDto
    {
        /// <summary>
        /// ID povrsine
        /// </summary>
        public Guid PovrsinaId { get; set; }

        /// <summary>
        /// Povrsina zasticene zone
        /// </summary>
        public int PovrsinaZZone { get; set; }

        /// <summary>
        /// Podaci o parceli
        /// </summary>
        public ParcelaDto? Parcela { get; set; }

        /// <summary>
        /// Podaci o zasticenoj zoni
        /// </summary>
        public ZasticenaZonaDto? ZasticenaZona { get; set; }
    }
}
