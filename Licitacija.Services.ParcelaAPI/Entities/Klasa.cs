using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.ParcelaAPI.Entities
{
    /// <summary>
    /// Predstavlja model klase
    /// </summary>
    public class Klasa
    {
        /// <summary>
        /// ID klase
        /// </summary>
        [Key]
        public Guid KlasaId { get; set; } = Guid.NewGuid();

        /// <summary>
        /// naziv klase
        /// </summary>
        [Required]
        public string KlasaNaziv { get; set; } = String.Empty;

        /// <summary>
        /// Parcele
        /// </summary>
        [JsonIgnore]
        public IList<Parcela> Parcele { get; set; }

    }
}
