using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.PredradnjeNadmetanjaAPI.Entities
{

    [Index(nameof(PredradnjeNadmetanjaNaziv), IsUnique = true)]
    public class PredradnjeNadmetanja
    {
        /// <summary>
        /// ID predradnje nadmetanja.
        /// </summary>
        [Key]
        public Guid PredradnjeNadmetanjaId { get; set; }

        /// <summary>
        /// Naziv predradnje nadmetanja.
        /// </summary>
        [Required]
        public string PredradnjeNadmetanjaNaziv { get; set; }  = String.Empty;

        public Guid? FazaId { get; set; }
    }
}
