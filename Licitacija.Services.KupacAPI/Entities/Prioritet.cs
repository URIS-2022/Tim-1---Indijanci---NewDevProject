using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace Licitacija.Services.KupacAPI.Entities
{
    [Index(nameof(PrioritetNaziv), IsUnique = true)]
    public class Prioritet
    {
        /// <summary>
        /// ID prioriteta.
        /// </summary>
        [Key]
        public Guid PrioritetId { get; set; }

        /// <summary>
        /// Naziv prioriteta.
        /// </summary>
        public string PrioritetNaziv { get; set; } = String.Empty;

        /// <summary>
        /// Lista kupaca sa datim prioritetom.
        /// </summary>
        [JsonIgnore]
        public IList<Kupac> Kupac { get; set; }
    }
}
