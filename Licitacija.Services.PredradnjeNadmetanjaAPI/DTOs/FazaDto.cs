namespace Licitacija.Services.PredradnjeNadmetanjaAPI.DTOs
{
    /// <summary>
    /// DTO faze licitacije.
    /// </summary>
    public class FazaDto
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
