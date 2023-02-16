using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Licitacija.Services.KomisijaAPI.Entities
{
    public class LicnostKomisija
    {
        /// <summary>
        /// Id ličnosti.
        /// </summary>
        public Guid LicnostId { get; set; }

        /// <summary>
        /// Id komisije.
        /// </summary>
        public Guid KomisijaId { get; set; }

        /// <summary>
        /// Ličnost.
        /// </summary>
        public Licnost? Licnost { get; set; }

        /// <summary>
        /// Komisija.
        /// </summary>
        public Komisija? Komisija { get; set; }
    }
}
