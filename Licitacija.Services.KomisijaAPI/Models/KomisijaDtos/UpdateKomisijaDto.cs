using Licitacija.Services.KomisijaAPI.Entities;
using Licitacija.Services.KomisijaAPI.Models.ExchangeDtos;

namespace Licitacija.Services.KomisijaAPI.Models.KomisijaDtos
{
    public class UpdateKomisijaDto
    {
        /// <summary>
        /// Id  komisije.
        /// </summary>
        public Guid KomisijaId { get; set; }

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
