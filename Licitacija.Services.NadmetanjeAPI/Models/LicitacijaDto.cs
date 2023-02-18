namespace Licitacija.Services.NadmetanjeAPI.Models
{
    /// <summary>
    /// Model licitacije.
    /// </summary>
    public class LicitacijaDto
    {
        /// <summary>
        /// ID Licitacije
        /// </summary>
        public Guid LicitacijaId { get; set; }

        /// <summary>
        /// Broj icitacije
        /// </summary>
        public int Broj { get; set; }

        /// <summary>
        /// Godine licitacije
        /// </summary>
        public int Godina { get; set; }

        /// <summary>
        /// Datum licitacije
        /// </summary>
        public DateTime Datum { get; set; }

        /// <summary>
        /// Ogranicenje licitacije
        /// </summary>
        public int Ogranicenje { get; set; }

        /// <summary>
        /// Korak cene licitacije
        /// </summary>
        public int KorakCene { get; set; }

        /// <summary>
        /// Rok za prijave licitacije
        /// </summary>
        public DateTime RokZaPrijave { get; set; }
    }
}
