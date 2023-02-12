using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Licitacija.Services.ParcelaAPI.Entities
{
    /// <summary>
    /// Predstavlja model dela parcele
    /// </summary>
    public class DeoParcele
    {
        /// <summary>
        /// ID dela parcele
        /// </summary>
        [Key]
        public Guid DeoParceleId { get; set; } = Guid.NewGuid();

        /// <summary>
        /// ID povrsine dela parcele
        /// </summary>
        [Required]
        public int PovrsinaDelaParcele { get; set; }

        /// <summary>
        /// ID parcele
        /// </summary>
        [ForeignKey(nameof(Parcela))]
        public Guid ParcelaId { get; set; }

        public Parcela? Parcela { get; set; }

        public Guid EtapaId { get; set; }
        public Guid OtvaranjePonudaId { get; set; }

    }
}
