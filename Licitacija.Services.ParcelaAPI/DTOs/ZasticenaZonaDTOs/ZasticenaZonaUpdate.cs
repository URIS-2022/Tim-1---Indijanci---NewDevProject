﻿using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.ParcelaAPI.DTOs.ZasticenaZonaDTOs
{
    /// <summary>
    /// Model za azuriranje zasticene zone
    /// </summary>
    public class ZasticenaZonaUpdateDTO
    {
        /// <summary>
        /// ID zasticene zone
        /// </summary>
        public Guid ZZonaId { get; set; }

        /// <summary>
        /// Naziv zasticene zone
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti naziv zasticene zone parcele")]
        [StringLength(70, ErrorMessage = "Maximum 70 karaktera u nazivu")]
        public string ZZonaNaziv { get; set; } = String.Empty;
    }
}
