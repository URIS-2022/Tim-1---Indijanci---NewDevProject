using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.NadmetanjeAPI.Entities
{
    public class StatusNadmetanja
    {
        /// <summary>
        /// ID statusa nadmetanja.
        /// </summary>
        [Key]
        public Guid StatusNadmetanjaId { get; set; }

        /// <summary>
        /// Naziv statusa nadmetanja.
        /// </summary>
        public string? StatusNadmetanjaNaziv { get; set; }

        public ICollection<Nadmetanje>? Nadmetanja { get; set; }
    }
}
