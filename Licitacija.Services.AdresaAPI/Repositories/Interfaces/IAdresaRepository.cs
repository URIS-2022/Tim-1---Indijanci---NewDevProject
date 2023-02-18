using Licitacija.Services.AdresaAPI.Entities;
using System.Linq.Expressions;

namespace Licitacija.Services.AdresaAPI.Repositories.Interfaces
{
    public interface IAdresaRepository
    {
        Task<IEnumerable<Adresa>> GetAll();

        Task<Adresa> Get(Guid id);

        Task<Adresa> GetAdresaWithoutDrzava(Guid adresaId);
    }
}
