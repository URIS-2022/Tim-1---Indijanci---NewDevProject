using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Licitacija.Services.KupacAPI.Entities
{
    [Index(nameof(JMBG), IsUnique = true)]
    public class FizickoLice
    {
        /// <summary>
        /// ID fizickog lica.
        /// </summary>
        [Key]
        public Guid FizickoLiceId { get; set; }

        /// <summary>
        /// ID kupca (strani kljuc).
        /// </summary>
        [Required]
        [ForeignKey(nameof(Kupac))]
        public Guid KupacId { get; set; }

        /// <summary>
        /// FL ime.
        /// </summary>
        [Required]
        public string FizickoLiceIme { get; set; } = String.Empty;

        /// <summary>
        /// Fl prezime.
        /// </summary>
        [Required]
        public string FizickoLicePrezime { get; set; } = String.Empty;

        /// <summary>
        /// Jedinstveni maticni broj gradjana.
        /// </summary>
        [Required]
        public string JMBG { get; set; } = String.Empty;

        /// <summary>
        /// Podaci o kipcu.
        /// </summary>
        [JsonIgnore]
        public Kupac Kupac { get; set; }
    }
}
