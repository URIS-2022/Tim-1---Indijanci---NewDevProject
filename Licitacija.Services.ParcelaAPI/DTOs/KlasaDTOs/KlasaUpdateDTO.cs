﻿using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.ParcelaAPI.DTOs.KlasaDTOs
{
    /// <summary>
    /// Model za azuriranje klase
    /// </summary>
    public class KlasaUpdateDTO
    {
        /// <summary>
        /// ID klase
        /// </summary>
        public Guid KlasaId { get; set; }

        /// <summary>
        /// Naziv klase
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti naziv klase parcele")]
        [StringLength(50, ErrorMessage = "Maximum 50 karaktera u nazivu")]
        public string KlasaNaziv { get; set; } = String.Empty;
    }
}
