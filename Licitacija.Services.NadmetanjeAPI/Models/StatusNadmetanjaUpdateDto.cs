namespace Licitacija.Services.NadmetanjeAPI.Models
{
    public class StatusNadmetanjaUpdateDto
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
