using Licitacija.Services.DokumentAPI.Entities;
using Newtonsoft.Json;
using Licitacija.Services.DokumentAPI.Models.ExchangeDtos;

namespace Licitacija.Services.DokumentAPI.Models.DokumentDtos
{
    public class GetDokumentDto
    {
        /// <summary>
        /// Id Dokumenta.
        /// </summary>
        public Guid DokumentId { get; set; }

        /// <summary>
        /// Zavodni broj dokumenta.
        /// </summary>
        public string ZavodniBroj { get; set; } = string.Empty;

        /// <summary>
        /// Datum potpisivanja dokumenta.
        /// </summary>
        public DateTime DatumPotpisivanja { get; set; }

        /// <summary>
        /// Datum donosenja dokumenta.
        /// </summary>
        public DateTime DatumDonosenja { get; set; }

        /// <summary>
        /// Rokovi dospeća ugovora o zakupu.
        /// </summary>
        public string Sablon { get; set; } = string.Empty;

        /// <summary>
        /// Id statusa dokumenta (strani kljuc).
        /// </summary>
        [JsonIgnore]
        public Guid StatusDokumentaId { get; set; }

        /// <summary>
        /// Status dokumenta.
        /// </summary>
        public StatusDokumenta StatusDokumenta { get; set; } = new StatusDokumenta();

        /// <summary>
        /// Id kupca (kupac mikroservis).
        /// </summary>
        [JsonIgnore]
        public Guid? KupacId { get; set; }

        /// <summary>
        /// Kupac.
        /// </summary>
        public KupacDto? Kupac { get; set; }

        /// <summary>
        /// Podaci o eksternom dokumentu.
        /// </summary>
        public EksterniDokument? EksterniDokument { get; set; }

        /// <summary>
        /// Podaci o ugovoru o zakupu.
        /// </summary>
        public UgovorOZakupu? UgovorOZakupu { get; set; }
    }
}
