using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Licitacija.Services.ParcelaAPI.Entities
{
    /// <summary>
    /// Predstavlja model povrsine
    /// </summary>
    public class Povrsina
    {
        /// <summary>
        /// ID povrsine
        /// </summary>
        [Key]
        public Guid PovrsinaId { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Povrsina zasticene zone
        /// </summary>
        [Required]
        public int PovrsinaZZone { get; set; }

        /// <summary>
        /// ID parcele
        /// </summary>
        [ForeignKey(nameof(Parcela))]
        public Guid ParcelaId { get; set; }

        public Parcela? Parcela { get; set; }

        /// <summary>
        /// ID zasticene zone
        /// </summary>
        [ForeignKey(nameof(ZasticenaZona))]
        public Guid ZZonaId { get; set; }

        public ZasticenaZona? ZasticenaZona { get; set; }
    }
}
