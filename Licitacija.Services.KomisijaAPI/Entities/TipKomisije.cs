using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.KomisijaAPI.Entities
{
    public class TipKomisije
    {
        /// <summary>
        /// Id tipa komisije.
        /// </summary>
        [Key]
        public Guid TipKomisijeId { get; set; }

        /// <summary>
        /// Naziv tipa komisije.
        /// </summary>
        [Required]
        public string? TipKomisijeNaziv { get; set; }

        public List<Komisija>? Komisije { get; set; }

    }
}
