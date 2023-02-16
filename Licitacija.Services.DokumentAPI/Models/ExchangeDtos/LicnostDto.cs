namespace Licitacija.Services.DokumentAPI.Models.ExchangeDtos
{
    public class LicnostDto
    {
        /// <summary>
        /// Id licnosti.
        /// </summary>
        public Guid LicnostId { get; set; }

        /// <summary>
        /// Ime licnosti.
        /// </summary>
        public string? Ime { get; set; }

        /// <summary>
        /// Prezime licnosti.
        /// </summary>
        public string? Prezime { get; set; }

        /// <summary>
        /// Funkcija licnosti.
        /// </summary>
        public string? Funkcija { get; set; }
    }
}
