using Licitacija.Services.ZalbaAPI.Entities;

namespace Licitacija.Services.ZalbaAPI.Repositories.Interfaces
{
    public interface IRadnjaNaOsnovuZalbeRepository
    {
        List<RadnjaNaOsnovuZalbe> GetAll();
        RadnjaNaOsnovuZalbe GetRadnjaNaOsnovuZalbe(Guid id);
        void InsertRadnjaNaOsnovuZalbe(RadnjaNaOsnovuZalbe radnjaNaOsnovuZalbe);
        void DeleteRadnjaNaOsnovuZalbe(Guid id);
        void UpdateRadnjaNaOsnovuZalbe(RadnjaNaOsnovuZalbe radnjaNaOsnovuZalbe);
        bool Save();
    }
}
