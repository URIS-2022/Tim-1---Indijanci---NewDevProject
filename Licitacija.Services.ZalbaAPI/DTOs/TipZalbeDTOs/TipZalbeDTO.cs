﻿namespace Licitacija.Services.ZalbaAPI.DTOs.TipZalbeDTOs
{
    public class TipZalbeDTO
    {
        /// <summary>
        /// ID tipa žalbe
        /// </summary>
        public Guid TipZalbeId { get; set; }

        /// <summary>
        /// Naziv tipa žalbe
        /// </summary>
        public string TipZalbeNaziv { get; set; }
    }
}
