namespace Licitacija.Services.ZavrsneRadnjeAPI.DTOs.ExchangeDto
{
    /// <summary>
    /// DTO faze licitacije.
    /// </summary>
    public class FazaLicitacijeDto
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
