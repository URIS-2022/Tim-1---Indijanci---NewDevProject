using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Licitacija.Services.DokumentAPI.Entities
{
    public class Dokument
    {
        /// <summary>
        /// Id Dokumenta.
        /// </summary>
        [Key]
        public Guid DokumentId { get; set; }

        /// <summary>
        /// Zavodni broj dokumenta.
        /// </summary>
        [Required]
        public string ZavodniBroj { get; set; } = string.Empty;

        /// <summary>
        /// Datum potpisivanja dokumenta.
        /// </summary>
        [Required]
        public DateTime DatumPotpisivanja { get; set; }

        /// <summary>
        /// Datum donosenja dokumenta.
        /// </summary>
        [Required]
        public DateTime DatumDonosenja { get; set; }

        /// <summary>
        /// Rokovi dospeća ugovora o zakupu.
        /// </summary>
        [Required]
        public string Sablon { get; set; } = string.Empty;

        /// <summary>
        /// Id statusa dokumenta (strani kljuc).
        /// </summary>
        [Required]
        [ForeignKey(nameof(StatusDokumenta))]
        public Guid StatusDokumentaId { get; set; }

        /// <summary>
        /// Status dokumenta.
        /// </summary>
        [Required]
        public StatusDokumenta StatusDokumenta { get; set; } = new StatusDokumenta();

        /// <summary>
        /// Id kupca (kupac mikroservis).
        /// </summary>
        public Guid? KupacId { get; set; }

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
