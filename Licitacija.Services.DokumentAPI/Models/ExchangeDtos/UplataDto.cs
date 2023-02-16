using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.DokumentAPI.Models.ExchangeDtos
{
    public class UplataDto
    {
        /// <summary>
        /// ID uplate.
        /// </summary>
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
        public decimal Iznos { get; set; }

        /// <summary>
        /// Svrha uplate.
        /// </summary>
        public string SvrhaUplate { get; set; } = string.Empty;

        /// <summary>
        /// Datum uplate.
        /// </summary>
        public DateTime DatumUplate { get; set; }
    }
}
