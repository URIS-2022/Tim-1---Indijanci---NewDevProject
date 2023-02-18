using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.DokumentAPI.Models.StatusDokumentaDtos
{
    public class UpdateStatusDokumentaDto
    {

        /// <summary>
        /// ID Statusa dokumenta.
        /// </summary>
        public Guid StatusDokumentaId { get; set; }
        /// <summary>
        /// Naziv statusa dokumenta.
        /// </summary>
        public string StatusDokumentaNaziv { get; set; } = string.Empty;
    }
}
