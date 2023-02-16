using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Licitacija.Services.ParcelaAPI.Entities
{
    /// <summary>
    /// Predstavlja model povrsine
    /// </summary>
    [Keyless]
    public class Povrsina
    {
        /// <summary>
        /// povrsina zasticene zone
        /// </summary>
        [Required]
        public int PovrsinaZZone { get; set; }

        /// <summary>
        /// ID parcele
        /// </summary>
        public Guid ParcelaId { get; set; }

        public Parcela? Parcela { get; set; }

        /// <summary>
        /// ID zasticene zone
        /// </summary>
        public Guid ZZonaId { get; set; }

        public ZasticenaZona? ZasticenaZona { get; set; }
    }
}
