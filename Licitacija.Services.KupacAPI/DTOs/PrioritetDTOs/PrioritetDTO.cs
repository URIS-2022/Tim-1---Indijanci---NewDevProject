namespace Licitacija.Services.KupacAPI.DTOs.PrioritetDTOs
{
    /// <summary>
    /// DTO za prioritet.
    /// </summary>
    public class PrioritetDto
    {
        /// <summary>
        /// ID prioriteta.
        /// </summary>
        public Guid PrioritetId { get; set; }

        /// <summary>
        ///Naziv prioriteta.
        /// </summary>
        public string PrioritetNaziv { get; set; } = String.Empty;
    }
}
