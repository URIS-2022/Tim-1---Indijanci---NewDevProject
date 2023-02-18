namespace Licitacija.Services.KomisijaAPI.Models.LicnostKomisijaDtos
{
    public class NovaLicnostKomisijaDto
    {
        /// <summary>
        /// Id ličnosti.
        /// </summary>
        public Guid LicnostId { get; set; }

        /// <summary>
        /// Id komisije.
        /// </summary>
        public Guid KomisijaId { get; set; }
    }
}
