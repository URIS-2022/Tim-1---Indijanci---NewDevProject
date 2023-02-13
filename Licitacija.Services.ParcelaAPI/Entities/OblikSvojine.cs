using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Licitacija.Services.ParcelaAPI.Entities
{
    /// <summary>
    /// Predstavlja model za oblik svojine
    /// </summary>
    public class OblikSvojine
    {
        /// <summary>
        /// ID oblika svojine
        /// </summary>
        [Key]
        public Guid OblikSvojineId { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Naziv tipa oblika svojine
        /// </summary>
        [Required]
        public string OblikSvojineNaziv { get; set; } = String.Empty;

        /// <summary>
        /// Parcele
        /// </summary>
        [JsonIgnore]
        public IList<Parcela> Parcele { get; set; }
    }
}
