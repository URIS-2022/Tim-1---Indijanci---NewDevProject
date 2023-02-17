using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.DokumentAPI.Models.StatusDokumentaDtos
{
    public class AddStatusDokumentaDto
    {
        /// <summary>
        /// Naziv statusa dokumenta.
        /// </summary>
        public string StatusDokumentaNaziv { get; set; } = string.Empty;
    }
}
