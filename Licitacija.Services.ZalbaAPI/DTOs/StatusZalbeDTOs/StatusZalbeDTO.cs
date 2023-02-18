namespace Licitacija.Services.ZalbaAPI.DTOs.StatusZalbeDTOs
{
    public class StatusZalbeDto
    {
        /// <summary>
        /// ID statusa zalbe
        /// </summary>
        public Guid StatusZalbeId { get; set; }

        /// <summary>
        /// Naziv statusa žalbe 
        /// </summary>
        public string StatusZalbeNaziv { get; set; }
    }
}
