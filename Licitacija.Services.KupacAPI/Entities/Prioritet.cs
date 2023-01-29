using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace Licitacija.Services.KupacAPI.Entities
{
    [Index(nameof(PrioritetNaziv), IsUnique = true)]
    public class Prioritet
    {
        [Key]
        public Guid PrioritetId { get; set; }    

        public string PrioritetNaziv { get; set; } = String.Empty;
    }
}
