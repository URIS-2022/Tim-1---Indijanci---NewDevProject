namespace Licitacija.Services.DokumentAPI.Models.StatusDokumentaDtos
{
    public class NoviStatusDokumentaDto
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
