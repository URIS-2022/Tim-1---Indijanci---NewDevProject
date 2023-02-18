namespace Licitacija.Services.NadmetanjeAPI.Models
{
    /// <summary>
    /// Model statusa nadmetanja.
    /// </summary>
    public class StatusNadmetanjaDto
    {
        /// <summary>
        /// ID statusa nadmetanja.
        /// </summary>
        public Guid StatusNadmetanjaId { get; set; }

        /// <summary>
        /// Naziv statusa nadmetanja.
        /// </summary>
        public string? StatusNadmetanjaNaziv { get; set; }
    }
}
