using Licitacija.Services.LicitacijaAPI.DTOs.LicitacijaDTOs;

namespace Licitacija.Services.LicitacijaAPI.DTOs.ExchangeDTOs
{
    /// <summary>
    /// DTO faze licitacije sa osnnovnim informacijama.
    /// </summary>
    public class FazaLicitacijeBasicInfoDto
    {
        /// <summary>
        /// ID faze licitacije.
        /// </summary>
        public Guid FazaId { get; set; }

        /// <summary>
        /// Naziv faze Licitacije
        /// </summary>
        public String FazaNaziv { get; set; }

    }
}
