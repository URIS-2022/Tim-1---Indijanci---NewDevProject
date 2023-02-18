namespace Licitacija.Services.ZalbaAPI.DTOs.RadnjaNaOsnovuZalbeDTOs
{
    public class RadnjaNaOsnovuZalbeUpdateDto
    {
        /// <summary>
        /// ID radnje za zalbu
        /// </summary>
        public Guid RadnjaId { get; set; }

        /// <summary>
        /// Naziv radnje za žalbu
        /// </summary>
        public string RadnjaNaziv { get; set; }
    }
}
