using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.ParcelaAPI.Entities
{
    /// <summary>
    /// Predstavlja model za odvodnjavanje
    /// </summary>
    public class Odvodnjavanje
    {
        /// <summary>
        /// ID odvodnjavanja
        /// </summary>
        [Key]
        public Guid OdvodnjavanjeId { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Naziv tipa odvodnjavanja
        /// </summary>
        [Required]
        public string OdvNaziv { get; set; } = String.Empty;

        /// <summary>
        /// Parcele
        /// </summary>
        [JsonIgnore]
        public IList<Parcela> Parcele { get; set; }
    }
}
