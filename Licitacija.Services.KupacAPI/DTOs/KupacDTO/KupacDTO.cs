using Licitacija.Services.KupacAPI.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.KupacAPI.DTOs.KupacDTO
{
    public class KupacDTO
    {
        public Guid KupacId { get; set; }

        public string BrojTel1 { get; set; }

        public string? BrojTel2 { get; set; }

        public string Email { get; set; }

        public string BrojRacuna { get; set; }

        public int OstvarenPovrsina { get; set; }

        public bool? ImaZabranu { get; set; }

        public DateTime? DatumPocetkaZabrane { get; set; }

        public int? DuzinaTrajanjaZabrane { get; set; }

        public DateTime? DatumPrestankaZabrane { get; set; }

        public Prioritet? Prioritet { get; set; }

        public FizickoLice? FizickoLice { get; set; }

        public PravnoLice? PravnoLice { get; set; }
    }
}
