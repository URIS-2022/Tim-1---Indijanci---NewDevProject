namespace Licitacija.Services.ZalbaAPI.DTOs.ExchangeDTOs
{
    public class FazaLicitacijeDTO
    {
        /// <summary>
        /// ID faze licitacije
        /// </summary>
        public Guid FazaId { get; set; }

        /// <summary>
        /// Naziv faze Licitacije
        /// </summary>
        public String FazaNaziv { get; set; } = String.Empty;
    }
}
