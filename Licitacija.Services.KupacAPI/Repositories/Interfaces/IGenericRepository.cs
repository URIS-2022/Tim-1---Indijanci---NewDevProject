namespace Licitacija.Services.KupacAPI.Repositories.Interfaces
{
    
    public interface IGenericRepository<T> where T : class
    {
        Task Insert(T entity);

        Task Delete(Guid guid);

        void Update(T entity);
    }
}
