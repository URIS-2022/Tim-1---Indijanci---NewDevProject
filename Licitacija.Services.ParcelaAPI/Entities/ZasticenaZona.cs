using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.ParcelaAPI.Entities
{
    /// <summary>
    /// Predstavlja model zasticene zone
    /// </summary>
    public class ZasticenaZona
    {
        /// <summary>
        /// ID zasticene zone
        /// </summary>
        [Key]
        public Guid ZZonaId { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Oznaka zasticene zone
        /// </summary>
        [Required]
        public string ZZonaNaziv { get; set; } = String.Empty;

        /// <summary>
        /// Povrsine
        /// </summary>
        [JsonIgnore]
        public IList<Povrsina> Povrsine { get; set; }

    }
}
