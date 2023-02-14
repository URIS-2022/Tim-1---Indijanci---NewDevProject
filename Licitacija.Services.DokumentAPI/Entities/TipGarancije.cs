using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.Dokument.API.Entities
{
    public class TipGarancije
    {
        /// <summary>
        /// ID tipa garancije.
        /// </summary>
        [Key]
        public Guid TipGarancijeId { get; set; }

        /// <summary>
        /// Naziv tipa garancije.
        /// </summary>
        [Required]
        public string TipGarancijeNaziv { get; set; } = String.Empty;
    }
}
