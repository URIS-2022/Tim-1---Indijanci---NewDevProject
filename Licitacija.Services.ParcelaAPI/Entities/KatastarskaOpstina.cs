using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.ParcelaAPI.Entities
{
    /// <summary>
    /// Predstavlja model za katastarsku opstinu
    /// </summary>
    public class KatastarskaOpstina
    {
        /// <summary>
        /// ID katastarske opstine
        /// </summary>
        [Key]
        public Guid KatOpstinaId { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Naziv katastarske opstine
        /// </summary>
        [Required]
        public string KatOpstinaNaziv { get; set; } = String.Empty;

        /// <summary>
        /// Parcele
        /// </summary>
        [JsonIgnore]
        public IList<Parcela> Parcele { get; set; }
    }
}
