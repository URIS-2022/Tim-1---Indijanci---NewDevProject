using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.KomisijaAPI.Entities
{
    public class Licnost
    {
        /// <summary>
        /// Id ličnosti.
        /// </summary>
        [Key]
        public Guid LicnostId { get; set; }

        /// <summary>
        /// Ime ličnosti.
        /// </summary>
        [Required]
        public string? Ime { get; set; }

        /// <summary>
        /// Prezime ličnosti.
        /// </summary>
        [Required]
        public string? Prezime { get; set; }

        /// <summary>
        /// Funkcija ličnosti.
        /// </summary>
        [Required]
        public string? Funkcija { get; set; }
    }
}
