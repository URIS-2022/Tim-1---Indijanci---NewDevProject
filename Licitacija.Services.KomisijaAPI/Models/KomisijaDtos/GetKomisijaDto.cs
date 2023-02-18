using Licitacija.Services.KomisijaAPI.Entities;
using Licitacija.Services.KomisijaAPI.Models.ExchangeDtos;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Licitacija.Services.KomisijaAPI.Models.KomisijaDtos
{
    public class GetKomisijaDto
    {
        /// <summary>
        /// Id  komisije.
        /// </summary>
        public Guid KomisijaId { get; set; }

        /// <summary>
        /// Id  tipa komisije (strani kljuc).
        /// </summary>
        [JsonIgnore]
        public Guid TipKomisijeId { get; set; }

        /// <summary>
        /// Id  programa (strani kljuc, mikroservis ProgramLicitacije).
        /// </summary>
        [JsonIgnore]
        public Guid? ProgramId { get; set; }

        /// <summary>
        /// Id  predradnje nadmetanja (strani kljuc, mikroservis PredradnjaNadmetanja).
        /// </summary>
        [JsonIgnore]
        public Guid? PredradnjaNadmetanjaId { get; set; }

        /// <summary>
        /// Tip komisije.
        /// </summary>
        public TipKomisije? TipKomisije { get; set; }

        /// <summary>
        /// Program licitacije.
        /// </summary>
        public ProgramDto? Program { get; set; }

        /// <summary>
        /// Predradnja nadmetanja.
        /// </summary>
        public PredradnjaNadmetanjaDto? PredradnjaNadmetanja { get; set; }
    }
}
