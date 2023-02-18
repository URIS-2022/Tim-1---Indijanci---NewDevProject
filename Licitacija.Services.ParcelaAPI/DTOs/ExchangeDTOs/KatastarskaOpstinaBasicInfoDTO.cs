namespace Licitacija.Services.ParcelaAPI.DTOs.ExchangeDTOs
{
    /// <summary>
    /// DTO katastarska opstina sa osnovnim informacijama.
    /// </summary>
    public class KatastarskaOpstinaBasicInfoDto
    {
        /// <summary>
        /// ID katastarske opstine
        /// </summary>
        public Guid KatOpstinaId { get; set; }

        /// <summary>
        /// Naziv katastarske opstine
        /// </summary>
        public string KatOpstinaNaziv { get; set; }
    }
}
