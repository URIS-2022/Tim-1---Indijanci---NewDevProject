using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Licitacija.Services.NadmetanjeKupacAPI.Entities
{
    public class OvlascenoLice
    {
        /// <summary>
        /// ID ovlascenoLice
        /// </summary>
        [Key]
        public Guid OvlascenoLiceId { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Ime
        /// </summary>
        [Required]
        public string Ime { get; set; } = String.Empty;

        /// <summary>
        /// Prezime
        /// </summary>
        [Required]
        public string Prezime { get; set; } = String.Empty;

        /// <summary>
        /// BrojPasosa
        /// </summary>
        public string BrojPasosa { get; set; } = String.Empty;

        /// <summary>
        /// JMBG
        /// </summary>
        public string JMBG { get; set; } = String.Empty;

        /// <summary>
        /// Id adresa - veza sa mikroservisom Adresa 
        /// </summary>
        public Guid? AdresaId { get; set; }

        [JsonIgnore]
        public IList<NadmetanjeKupacEntity>? NadmetanjeKupac { get; set; }

    }
}
