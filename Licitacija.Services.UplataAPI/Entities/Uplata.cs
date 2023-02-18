using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Licitacija.Services.UplataAPI.Models;

namespace Licitacija.Services.UplataAPI.Entities
{
    public class Uplata
    {
        /// <summary>
        /// ID uplate.
        /// </summary>
        [Key]
        public Guid UplataId { get; set; }

        /// <summary>
        /// Broj računa uplate.
        /// </summary>
        public string BrojRacuna { get; set; } = string.Empty;

        /// <summary>
        /// Poziv na broj uplate.
        /// </summary>
        public string PozivNaBroj { get; set; } = string.Empty;

        /// <summary>
        /// Iznos uplate.
        /// </summary>
        [Column(TypeName = "decimal(18,4)")]
        public decimal Iznos { get; set; }

        /// <summary>
        /// Svrha uplate.
        /// </summary>
        public string SvrhaUplate { get; set; } = string.Empty;

        /// <summary>
        /// Datum uplate.
        /// </summary>
        public DateTime DatumUplate { get; set; }

        /// <summary>
        /// ID kursa.
        /// </summary>
        public Guid? KursId { get; set; }

        /// <summary>
        /// Objekat kursa.
        /// </summary>
        public Kurs? Kurs { get; set; }

        /// <summary>
        /// Strani ključ kupca.
        /// </summary>
        public Guid KupacId { get; set; }
    }
}
