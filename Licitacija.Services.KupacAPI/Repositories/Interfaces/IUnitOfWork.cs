using Licitacija.Services.KupacAPI.Entities;

namespace Licitacija.Services.KupacAPI.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Prioritet> Prioritet { get; }

        IGenericRepository<KontaktOsoba> KontaktOsoba { get; }

        IGenericRepository<FizickoLice> FizickoLice { get; }

        IGenericRepository<PravnoLice> PravnoLice { get; }

        IGenericRepository<Kupac> Kupac { get; }

        Task Save();

    }
}
