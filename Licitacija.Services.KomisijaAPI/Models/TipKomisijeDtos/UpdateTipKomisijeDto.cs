namespace Licitacija.Services.KomisijaAPI.Models.TipKomisijeDtos
{
    public class UpdateTipKomisijeDto
    {
        /// <summary>
        /// Id tipa komisije.
        /// </summary>
        public Guid TipKomisijeId { get; set; }

        /// <summary>
        /// Naziv tipa komisije.
        /// </summary>
        public string? TipKomisijeNaziv { get; set; }
    }
}
