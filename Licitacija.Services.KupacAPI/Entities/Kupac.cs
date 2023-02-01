using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Licitacija.Services.KupacAPI.Entities
{
    public class Kupac
    {
        [Key]
        public Guid KupacId { get; set; }

        [Required]
        public string BrojTel1 { get; set; }

        public string? BrojTel2 { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string BrojRacuna { get; set; }

        [Required]
        public int OstvarenPovrsina { get; set; }

        [Required]
        public bool ImaZabranu { get; set; }

        public DateTime? DatumPocetkaZabrane { get; set; }

        public int? DuzinaTrajanjaZabrane { get; set; }

        public DateTime? DatumPrestankaZabrane { get; set; }

        [ForeignKey(nameof(Prioritet))]
        public Guid? PrioritetId { get; set; }

        public Prioritet? Prioritet { get; set; } 
        
        public FizickoLice? FizickoLice { get; set; }

        public PravnoLice? PravnoLice { get; set; }
    }
}
