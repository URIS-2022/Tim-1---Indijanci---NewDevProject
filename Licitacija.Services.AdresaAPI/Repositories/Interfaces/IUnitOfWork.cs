using Licitacija.Services.AdresaAPI.Entities;

namespace Licitacija.Services.AdresaAPI.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Adresa> Adresa { get; }

        IGenericRepository<Drzava> Drzava { get; }

        Task Save();//sve izmene su samo staged dok se ne pozove ova metoda, onda se sve propagira

    }
}
