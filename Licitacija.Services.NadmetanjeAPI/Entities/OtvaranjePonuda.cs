﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Licitacija.Services.NadmetanjeAPI.Entities
{
    public class OtvaranjePonuda
    {
        /// <summary>
        /// ID otvaranja ponuda.
        /// </summary>
        [Key]
        public Guid OtvaranjePonudaId { get; set; }

        /// <summary>
        /// ID nadmetanja.
        /// </summary>
        [ForeignKey("NadmetanjeId")]
        public Guid NadmetanjeId { get; set; }
    }
}
