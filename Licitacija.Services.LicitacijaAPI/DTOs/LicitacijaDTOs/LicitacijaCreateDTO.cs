﻿using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Licitacija.Services.LicitacijaAPI.DTOs.LicitacijaDTOs
{
    /// <summary>
    /// Model za kreiranje licitacije.
    /// </summary>
    public class LicitacijaCreateDTO 
    {
        /// <summary>
        /// Broj icitacije
        /// </summary>
        /// 
        [Required(ErrorMessage = "Obavezno je uneti broj licitacije.")]
        public int Broj { get; set; }

        /// <summary>
        /// Godina licitacije
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti godinu licitacije.")]
        public int Godina { get; set; }

        /// <summary>
        /// Datum licitacije
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti datum licitacije.")]
        public DateTime Datum { get; set; }

        /// <summary>
        /// Ogranicenje licitacije
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti ogranicenje licitacije.")]
        public int Ogranicenje { get; set; }

        /// <summary>
        /// Korak cene licitacije
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti korak cene licitacije.")]
        public int KorakCene { get; set; }

        /// <summary>
        /// Rok za prijave licitacije
        /// </summary>
        [Required(ErrorMessage = "Obavezno je uneti rok za prijavu licitacije.")]
        public DateTime RokZaPrijave { get; set; }


    }
}
