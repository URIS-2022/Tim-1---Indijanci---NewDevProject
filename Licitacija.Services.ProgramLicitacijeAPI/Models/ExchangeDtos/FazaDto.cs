namespace Licitacija.Services.ProgramLicitacijeAPI.Models.ExchangeDtos
{
    public class FazaDto
    {
        /// <summary>
        /// ID faze licitacije.
        /// </summary>
        public Guid FazaId { get; set; }

        /// <summary>
        /// Naziv faze Licitacije
        /// </summary>
        public string? FazaNaziv { get; set; }
    }
}
