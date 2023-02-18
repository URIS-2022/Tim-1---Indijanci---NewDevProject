using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Licitacija.Services.AdresaAPI.Repositories.Interfaces
{
    //genericki repozitorijum koji ce se deliti izmedju entiteta za operacije dodavanja, izmene i brisanja, dok ce 
        //se za pribavljanje podataka (getall i get) kreirati poseban repository za svaki entitet.
    public interface IGenericRepository<in T> where T : class
    {
        Task Insert(T entity);

        Task Delete(Guid guid);

        void Update(T entity);
    }
}
