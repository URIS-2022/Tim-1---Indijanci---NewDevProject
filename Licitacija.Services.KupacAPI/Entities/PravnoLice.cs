using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using JsonIgnoreAttribute = Newtonsoft.Json.JsonIgnoreAttribute;

namespace Licitacija.Services.KupacAPI.Entities
{
    [Index(nameof(MaticniBroj), IsUnique = true)]
    public class PravnoLice
    {
        /// <summary>
        /// ID pravnog lica.
        /// </summary>
        [Key]
        public Guid PravnoLiceId { get; set; }

        /// <summary>
        /// ID kupca (strani kljuc).
        /// </summary>
        [Required]
        [ForeignKey(nameof(Kupac))]
        public Guid KupacId { get; set; }

        /// <summary>
        /// Naziv pravnog lica.
        /// </summary>
        [Required]
        public string PravnoLiceNazv { get; set; } = String.Empty;

        /// <summary>
        /// Maticni broj pravnog lica.
        /// </summary>
        [Required]
        public string MaticniBroj { get; set; } = String.Empty;

        /// <summary>
        /// Broj faksa.
        /// </summary>
        public string? Faks { get; set; } = String.Empty;

        /// <summary>
        /// Podaci o kontakt osobi koja je strani kljuc.
        /// </summary>
        [ForeignKey(nameof(KontaktOsoba))]
        public Guid? KontaktOsobaId { get; set; }

        public KontaktOsoba? KontaktOsoba { get; set; }

        /// <summary>
        /// Podaci o kupcu.
        /// </summary>
        [JsonIgnore]
        public Kupac Kupac { get; set; }
    }
}
