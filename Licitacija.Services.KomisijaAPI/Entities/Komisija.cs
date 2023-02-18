using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Licitacija.Services.KomisijaAPI.Entities
{
    public class Komisija
    {
        /// <summary>
        /// Id  komisije.
        /// </summary>
        [Key]
        public Guid KomisijaId { get; set; }

        /// <summary>
        /// Id  tipa komisije (strani kljuc).
        /// </summary>
        [Required, ForeignKey(nameof(TipKomisije))]
        public Guid TipKomisijeId { get; set; }

        /// <summary>
        /// Id  programa (strani kljuc, mikroservis ProgramLicitacije).
        /// </summary>
        public Guid? ProgramId { get; set; }

        /// <summary>
        /// Id  predradnje nadmetanja (strani kljuc, mikroservis PredradnjaNadmetanja).
        /// </summary>
        public Guid? PredradnjaNadmetanjaId { get; set; }


        /// <summary>
        /// Tip komisije.
        /// </summary>
        public TipKomisije? TipKomisije { get; set; }

        
    }
}
