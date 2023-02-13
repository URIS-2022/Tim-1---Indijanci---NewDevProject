using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.NadmetanjeAPI.Entities
{
    public class StatusNadmetanja
    {
        [Key]
        public Guid StatusNadmetanjaId { get; set; }
        public string? StatusNadmetanjaNaziv { get; set; }

        public ICollection<Nadmetanje>? Nadmetanja { get; set; }
    }
}
