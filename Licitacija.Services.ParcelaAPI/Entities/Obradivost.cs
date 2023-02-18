using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.ParcelaAPI.Entities
{
    /// <summary>
    /// Predstavlja model obradivosti
    /// </summary>
    public class Obradivost
    {
        /// <summary>
        /// ID obradivosti
        /// </summary>
        [Key]
        public Guid ObradivostId { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Naziv tipa obradivosti
        /// </summary>
        [Required]
        public string ObradivostNaziv { get; set; } = String.Empty;

        /// <summary>
        /// Parcele
        /// </summary>
        [JsonIgnore]
        public IList<Parcela> Parcele { get; set; }
    }
}
