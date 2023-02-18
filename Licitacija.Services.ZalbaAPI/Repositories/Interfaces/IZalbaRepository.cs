using Licitacija.Services.ZalbaAPI.Entities;

namespace Licitacija.Services.ZalbaAPI.Repositories.Interfaces
{
    public interface IZalbaRepository
    {
        /// <summary>
        /// Dobijanje podataka o svim žalbama
        /// </summary>
        /// <returns></returns>
        List<Zalba> GetAll();
        /// <summary>
        /// Dobijanje žalbe po id-u
        /// </summary>
        /// <param name="zalbaId">Id žalbe</param>
        /// <returns></returns>
        Zalba GetZalba(Guid id);
        /// <summary>
        /// Kreiranje žalbe
        /// </summary>
        /// <param name="zalba">Objekat žalbe</param>
        /// <returns></returns>
        void InsertZalba(Zalba zalba);
        /// <summary>
        /// Brisanje žalbe
        /// </summary>
        /// <param name="zalbaId">Id žalbe</param>
        /// <returns></returns>
        void DeleteZalba(Guid id);
        /// <summary>
        /// Modifikacija žalbe
        /// </summary>
        /// <param name="zalba">Objekat žalbe</param>
        /// <returns></returns>
        void UpdateZalba(Zalba zalba);
        bool Save();

        /// <summary>
        /// Provera validnosti za unos žalbe
        /// </summary>
        /// <param name="zalba">Id broja table</param>
        /// <returns></returns>
        Task<bool> IsValidZalba(Zalba zalba);

    }
}
