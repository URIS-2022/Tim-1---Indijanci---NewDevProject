namespace Licitacija.Services.AdresaAPI.Repositories.Interfaces
{
    public interface IDrzavaRepository
    {
        Task<IEnumerable<Drzava>> GetAll();

        Task<Drzava> Get(Guid id);
    }
}
