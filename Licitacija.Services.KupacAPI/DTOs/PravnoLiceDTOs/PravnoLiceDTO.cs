using Licitacija.Services.KupacAPI.DTOs.KontaktOsobaDTOs;
using Licitacija.Services.KupacAPI.Entities;


namespace Licitacija.Services.KupacAPI.DTOs.PravnoLiceDTOs
{
    /// <summary>
    /// Model pravnog lica.
    /// </summary>
    public class PravnoLiceDto
    {
        /// <summary>
        /// ID kupca (strani kljuc).
        /// </summary>
        public Guid KupacId { get; set; }

        /// <summary>
        /// ID pravnog lica.
        /// </summary>
        public Guid PravnoLiceId { get; set; }

        /// <summary>
        /// Naziv pravnog lica.
        /// </summary>
        public string PravnoLiceNazv { get; set; }

        /// <summary>
        /// Maticni broj pravnog lica.
        /// </summary>
        public string MaticniBroj { get; set; }

        /// <summary>
        /// Broj faksa.
        /// </summary>
        public string? Faks { get; set; }

        /// <summary>
        /// Podaci o kontakt osobi.
        /// </summary>
        public KontaktOsobaDto? KontaktOsoba { get; set; }
    }
}
