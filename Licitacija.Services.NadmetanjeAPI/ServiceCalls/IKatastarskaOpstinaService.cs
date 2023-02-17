using Licitacija.Services.NadmetanjeAPI.Models;

namespace Licitacija.Services.NadmetanjeAPI.ServiceCalls
{
    public interface IKatastarskaOpstinaService
    {
        Task<KatastarskaOpstinaDto> GetKatastarskaOpstinaById(Guid id);
    }
}
