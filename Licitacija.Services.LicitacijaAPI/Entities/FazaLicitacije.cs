using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Licitacija.Services.LicitacijaAPI.Entities
{
    /// <summary>
    /// Entitet faza licitacije.
    /// </summary>
    public class FazaLicitacije
    {
        /// <summary>
        /// ID faze licitacije
        /// </summary>
        [Key]
        public Guid FazaId { get; set; } = new Guid();

        /// <summary>
        /// Naziv faze Licitacije
        /// </summary>
        [Required]
        public String FazaNaziv { get; set; } = String.Empty;

        /// <summary>
        /// ID Licitacije
        /// </summary>
        [ForeignKey(nameof(LicitacijaEntity))]
        public Guid? LicitacijaId { get; set; }

        public LicitacijaEntity Licitacija { get; set; }
    }
}

