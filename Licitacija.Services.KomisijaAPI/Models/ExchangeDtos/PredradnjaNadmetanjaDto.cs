namespace Licitacija.Services.KomisijaAPI.Models.ExchangeDtos
{
    public class PredradnjaNadmetanjaDto
    {
        /// <summary>
        /// ID predradnje nadmetanja.
        /// </summary>
        public Guid PredradnjeNadmetanjaId { get; set; }

        /// <summary>
        /// Naziv predradnje nadmetanja.
        /// </summary>
        public string PredradnjeNadmetanjaNaziv { get; set; } = String.Empty;
    }
}
