using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.PredradnjeNadmetanjaAPI.DTOs
{
    /// <summary>
    /// DTO predradnje nadmetanja.
    /// </summary>
    public class PredradnjeNadmetanjaDto
    {
        /// <summary>
        /// ID predradnje nadmetanja.
        /// </summary>
        public Guid PredradnjeNadmetanjaId { get; set; }

        /// <summary>
        /// Naziv predradnje nadmetanja.
        /// </summary>
        public string PredradnjeNadmetanjaNaziv { get; set; } = String.Empty;
    }
}
