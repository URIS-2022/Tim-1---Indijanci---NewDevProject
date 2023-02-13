namespace Licitacija.Services.KupacAPI.DTOs.ExchangeDTOs
{
    /// <summary>
    /// DTO kupca sa osnnovnim informacijama i tipom.
    /// </summary>
    public class KupacWithTipDto
    {
        /// <summary>
        /// ID kupca.
        /// </summary>
        public Guid KupacId { get; set; }

        /// <summary>
        /// Glavni broj telefona.
        /// </summary>
        public string BrojTel1 { get; set; }

        /// <summary>
        /// Email adresa kupca.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Ostvarena povrsina.
        /// </summary>
        public int OstvarenPovrsina { get; set; }

        /// <summary>
        /// Indikator da li kupac ima zabranu.
        /// </summary>
        public bool? ImaZabranu { get; set; }

        /// <summary>
        /// Ukoliko ima zabranu, datum njenog pocetja.
        /// </summary>
        public DateTime? DatumPocetkaZabrane { get; set; }

        /// <summary>
        /// Trajanje zabrane u godinama.
        /// </summary>
        public int? DuzinaTrajanjaZabrane { get; set; }

        /// <summary>
        /// Datum prestanka zabrane.
        /// </summary>
        public DateTime? DatumPrestankaZabrane { get; set; }

        /// <summary>
        /// Tip kupca (pravno ili fizicko lice).
        /// </summary>
        public string TipKupca { get; set; }
    }
}
