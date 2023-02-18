namespace Licitacija.Services.ParcelaAPI.DTOs.KatastarskaOpstinaDTOs
{
    /// <summary>
    /// Model za prikaz katastarske opstine
    /// </summary>
    public class KatastarskaOpstinaDto
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
