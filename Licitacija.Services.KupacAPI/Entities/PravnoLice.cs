using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Licitacija.Services.KupacAPI.Entities
{
    public class PravnoLice
    {
        [Required]
        [ForeignKey(nameof(Kupac))]
        public Guid KupacId { get; set; }

        public Guid PravnoLiceId { get; set; }

        [Required]
        public string PravnoLiceNazv { get; set; }

        [Required]
        public string MaticniBroj { get; set; }

        public string? Faks { get; set; }

        [ForeignKey(nameof(KontaktOsoba))]
        public Guid KontaktOsobaId { get; set; }

        public KontaktOsoba? KontaktOsoba { get; set; }
    }
}
