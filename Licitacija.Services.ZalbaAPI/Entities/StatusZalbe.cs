using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.ZalbaAPI.Entities
{
    [Index(nameof(StatusZalbeNaziv), IsUnique = true)]
    public class StatusZalbe
    {
        /// <summary>
        /// ID statusa žalbe
        /// </summary>
        [Key]
        public Guid StatusZalbeId { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Naziv statusa žalbe 
        /// </summary>
        [Required]
        public string StatusZalbeNaziv { get; set; } = String.Empty;

        [JsonIgnore]
        public IList<Zalba>? Zalba { get; set; }
    }
}
