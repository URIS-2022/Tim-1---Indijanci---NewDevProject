using Licitacija.Services.KomisijaAPI.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Licitacija.Services.KomisijaAPI.Models.LicnostKomisijaDtos
{
    public class AddLicnostKomisijaDto
    {
        /// <summary>
        /// Id komisije.
        /// </summary>
        public Guid KomisijaId { get; set; }
    }
}
