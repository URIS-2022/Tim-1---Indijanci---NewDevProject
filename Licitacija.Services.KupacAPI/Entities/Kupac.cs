using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace Licitacija.Services.KupacAPI.Entities
{
    public class Kupac
    {
        /// <summary>
        /// ID kupca.
        /// </summary>
        [Key]
        public Guid KupacId { get; set; }

        /// <summary>
        /// Glavni broj telefona.
        /// </summary>
        [Required]
        public string BrojTel1 { get; set; } = String.Empty;

        /// <summary>
        /// Dodatni broj telefona.
        /// </summary>
        public string? BrojTel2 { get; set; } = String.Empty;

        /// <summary>
        /// Email adresa kupca.
        /// </summary>
        [Required]
        public string Email { get; set; } = String.Empty;

        /// <summary>
        /// broj racuna.
        /// </summary>
        [Required]
        public string BrojRacuna { get; set; } = String.Empty;

        /// <summary>
        /// Ostvarena povrsina.
        /// </summary>
        [Required]
        public int OstvarenPovrsina { get; set; }

        /// <summary>
        /// Indikator da li kupac ima zabranu.
        /// </summary>
        [Required]
        public bool ImaZabranu { get; set; }

        /// <summary>
        /// Ukoliko ima zabranu, datum njenog pocetja.
        /// </summary>
        public DateTime? DatumPocetkaZabrane { get; set; }

        /// <summary>
        /// Trajanje zabrane u godinama.
        /// </summary>
        public int? DuzinaTrajanjaZabrane { get; set; }

        /// <summary>
        /// Datum prestanka zabrane.
        /// </summary>
        public DateTime? DatumPrestankaZabrane { get; set; }

        /// <summary>
        /// Tip kupca (pravno ili fizicko lice).
        /// </summary>
        public string? TipKupca { get; set; }

        /// <summary>
        /// Podaci o prioritetu koji je strani kljuc u kupcu.
        /// </summary>
        [ForeignKey(nameof(Prioritet))]
        public Guid? PrioritetId { get; set; }

        public Prioritet? Prioritet { get; set; }

        /// <summary>
        /// Podaci o FL.
        /// </summary>
        public FizickoLice? FizickoLice { get; set; }

        /// <summary>
        /// Podaci o PL.
        /// </summary>
        public PravnoLice? PravnoLice { get; set; }

        /// <summary>
        /// Strani kljuc adrese (mikroservis adresa).
        /// </summary>
        public Guid? AdresaId { get; set; }
    }
}
