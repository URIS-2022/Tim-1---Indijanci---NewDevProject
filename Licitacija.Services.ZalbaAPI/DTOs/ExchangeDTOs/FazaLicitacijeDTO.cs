namespace Licitacija.Services.ZalbaAPI.DTOs.ExchangeDTOs
{
    /// <summary>
    /// DTO faze licitacije sa osnnovnim informacijama.
    /// </summary>
    public class FazaLicitacijeDto
    {
        /// <summary>
        /// ID faze licitacije
        /// </summary>
        public Guid FazaId { get; set; }

        /// <summary>
        /// Naziv faze Licitacije
        /// </summary>
        public String FazaNaziv { get; set; }
    }
}
