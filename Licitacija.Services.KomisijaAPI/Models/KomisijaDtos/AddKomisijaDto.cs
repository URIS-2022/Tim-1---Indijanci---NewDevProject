using Licitacija.Services.KomisijaAPI.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.KomisijaAPI.Models.KomisijaDtos
{
    public class AddKomisijaDto
    {
        /// <summary>
        /// Id  tipa komisije (strani kljuc).
        /// </summary>
        public Guid TipKomisijeId { get; set; }

        /// <summary>
        /// Id  programa (strani kljuc, mikroservis ProgramLicitacije).
        /// </summary>
        public Guid? ProgramId { get; set; }

        /// <summary>
        /// Id  predradnje nadmetanja (strani kljuc, mikroservis PredradnjaNadmetanja).
        /// </summary>
        public Guid? PredradnjaNadmetanjaId { get; set; }
    }
}
