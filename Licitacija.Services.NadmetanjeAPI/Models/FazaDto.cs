namespace Licitacija.Services.NadmetanjeAPI.Models
{
    /// <summary>
    /// Model faze licitacije.
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
        public string? FazaNaziv { get; set; }
    }
}
