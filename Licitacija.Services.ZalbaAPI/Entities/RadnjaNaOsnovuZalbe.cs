using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.ZalbaAPI.Entities
{
    /// <summary>
    /// Predstavlja radnju za žalbu
    /// </summary>
    [Index(nameof(RadnjaNaziv), IsUnique = true)]
    public class RadnjaNaOsnovuZalbe
    {
        /// <summary>
        /// ID radnje za žalbu
        /// </summary>
        [Key]
        public Guid RadnjaId { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Naziv radnje za žalbu
        /// </summary>
        [Required]
        public string RadnjaNaziv { get; set; } = String.Empty;

        /// <summary>
        /// Lista kupaca sa datim prioritetom.
        /// </summary>
        [JsonIgnore]
        public IList<Zalba>? Zalba { get; set; }
    }
}
