using Licitacija.Services.UplataAPI.Models;

namespace Licitacija.Services.UplataAPI.ServiceCalls
{
    public interface IKupacService
    {
        public Task<KupacDto> GetKupacById(Guid kupacId);
    }
}
