using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.ParcelaAPI.Entities
{
    /// <summary>
    /// Prestavlja model kulture
    /// </summary>
    public class Kultura
    {
        /// <summary>
        /// ID kulture
        /// </summary>
        [Key]
        public Guid KulturaId { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Naziv kulture
        /// </summary>
        [Required]
        public string KulturaNaziv { get; set; } = String.Empty;

        /// <summary>
        /// Parcele
        /// </summary>
        [JsonIgnore]
        public IList<Parcela> Parcele { get; set; }
    }
}
