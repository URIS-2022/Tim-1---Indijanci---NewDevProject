using Licitacija.Services.DokumentAPI.Entities;
using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.DokumentAPI.Models.DokumentDtos
{
    public class NoviDokumentDto
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
        [Required]
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
        public Guid StatusDokumentaId { get; set; }

        /// <summary>
        /// Status dokumenta.
        /// </summary>
        public StatusDokumenta StatusDokumenta { get; set; } = new StatusDokumenta();
    }
}
