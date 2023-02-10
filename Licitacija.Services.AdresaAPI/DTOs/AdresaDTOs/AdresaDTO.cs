using Licitacija.Services.AdresaAPI.DTOs.Drzava;

namespace Licitacija.Services.AdresaAPI.DTOs.Adresa
{
    /// <summary>
    /// DTO za adresu.
    /// </summary>
    public class AdresaDto
    {
        /// <summary>
        /// ID adrese.
        /// </summary>
        public Guid AdresaId { get; set; }

        /// <summary>
        /// Naziv ulice.
        /// </summary>
        public string Ulica { get; set; } = string.Empty;

        /// <summary>
        /// Broj kuće/stana.
        /// </summary>
        public string Broj { get; set; } = string.Empty;

        /// <summary>
        /// Naziv mesta.
        /// </summary>
        public string Mesto { get; set; } = string.Empty;

        /// <summary>
        /// Poštanski broj mesta.
        /// </summary>
        public string PostanskiBroj { get; set; } = string.Empty;

        /// <summary>
        /// DTO objekat države.
        /// </summary>
        public DrzavaDto Drzava { get; set; }
    }
}
