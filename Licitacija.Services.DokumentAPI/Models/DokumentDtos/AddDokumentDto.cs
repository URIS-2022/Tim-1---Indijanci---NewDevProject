namespace Licitacija.Services.DokumentAPI.Models.DokumentDtos
{
    public class AddDokumentDto
    {
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
        public Guid StatusDokumentaId { get; set; }

        /// <summary>
        /// Id kupca (kupac mikroservis).
        /// </summary>
        public Guid? KupacId { get; set; }
    }
}
