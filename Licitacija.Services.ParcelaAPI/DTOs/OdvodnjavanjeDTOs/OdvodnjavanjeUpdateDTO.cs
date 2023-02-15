﻿using System.ComponentModel.DataAnnotations;

namespace Licitacija.Services.ParcelaAPI.DTOs.OdvodnjavanjeDTOs
{
    /// <summary>
    /// Model za azuriranje odvodnjavanja
    /// </summary>
    public class OdvodnjavanjeUpdateDTO
    {
        /// <summary>
        /// ID odvodnjavanja
        /// </summary>
        public Guid OdvodnjavanjeId { get; set; }

        /// <summary>
        /// Naziv odvodnjavanja
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti naziv odvodnjavanja parcele")]
        [StringLength(50, ErrorMessage = "Maximum 50 karaktera u nazivu")]
        public string OdvNaziv { get; set; } = String.Empty;
    }
}