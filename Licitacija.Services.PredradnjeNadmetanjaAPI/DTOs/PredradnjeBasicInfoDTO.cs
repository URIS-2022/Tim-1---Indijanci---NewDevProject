namespace Licitacija.Services.PredradnjeNadmetanjaAPI.DTOs
{
    /// <summary>
    /// DTO predradnje nadmetanja sa osnovnim informacijama.
    /// </summary>
    public class PredradnjeBasicInfoDto
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
