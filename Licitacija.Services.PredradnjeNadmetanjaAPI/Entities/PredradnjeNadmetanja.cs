using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.PredradnjeNadmetanjaAPI.Entities
{
    [Index(nameof(PredradnjeNadmetanjaNaziv), IsUnique = true)]
    public class PredradnjeNadmetanja
    {
        [Key]
        public Guid PredradnjeNadmetanjaId { get; set; }

        [Required]
        public string PredradnjeNadmetanjaNaziv { get; set; }  = String.Empty;
    }
}
