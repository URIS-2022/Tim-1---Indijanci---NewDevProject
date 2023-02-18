namespace Licitacija.Services.KupacAPI.DTOs.KontaktOsobaDTOs
{
    /// <summary>
    /// DTO za kontakt osobu.
    /// </summary>
    public class KontaktOsobaDto
    {
        /// <summary>
        /// ID kontakt osobe.
        /// </summary>
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
    }
}
