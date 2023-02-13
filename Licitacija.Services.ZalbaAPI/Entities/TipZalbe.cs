using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.ZalbaAPI.Entities
{
    [Index(nameof(TipZalbeNaziv), IsUnique = true)]
    public class TipZalbe
    {
        /// <summary>
        /// ID tipa žalbe
        /// </summary>
        [Key]
        public Guid TipZalbeId { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Naziv tipa žalbe
        /// </summary>
        [Required]
        public string TipZalbeNaziv { get; set; } = String.Empty;

        [JsonIgnore]
        public IList<Zalba>? Zalba { get; set; }
    }
}
