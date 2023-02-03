using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.PredradnjeNadmetanjaAPI.DTOs
{
    public class PredradnjeNadmetanjaDTO
    {
        public Guid PredradnjeNadmetanjaId { get; set; }

        public string PredradnjeNadmetanjaNaziv { get; set; } = String.Empty;
    }
}
