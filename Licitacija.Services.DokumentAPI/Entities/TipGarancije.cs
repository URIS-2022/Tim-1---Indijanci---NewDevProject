using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.DokumentAPI.Entities
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
        public string TipGarancijeNaziv { get; set; } = string.Empty;

        /// <summary>
        /// Svi ugovori u zakupu koji imaju dati tip garancije.
        /// </summary>
        public List<UgovorOZakupu>? UgovoriOZakupu { get; set; }

    }
}
