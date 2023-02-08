using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.KupacAPI.Entities
{
    public class KontaktOsoba
    {
        /// <summary>
        /// ID kontakt osobe.
        /// </summary>
        [Key]
        public Guid KontaktOsobaId { get; set; }

        /// <summary>
        /// Ime kontakt osobe.
        /// </summary>
        public string KontaktOsobaIme { get; set; } = String.Empty;

        /// <summary>
        /// Prezime kontakt osobe.
        /// </summary>
        public string KontaktOsobaPrezime { get; set; } = String.Empty;

        /// <summary>
        /// Funkcija kontakt osobe.
        /// </summary>
        public string Funkcija { get; set; } = String.Empty;

        /// <summary>
        /// Broj telefona kontakt osobe.
        /// </summary>
        public string Telefon { get; set; } = String.Empty;

        /// <summary>
        /// Lista pravnih lica date KO.
        /// </summary>
        [JsonIgnore]
        public IList<PravnoLice> PravnoLice { get; set; }   

    }
}
