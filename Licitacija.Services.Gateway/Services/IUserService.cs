using Licitacija.Services.Gateway.Dtos;

namespace Licitacija.Services.Gateway.Services
{
    public interface IUserService
    {
        Task<T> Login<T>(LoginDTO loginInfo);
        Task<T> Logout<T>();
        Task<T> Register<T>(RegisterDTO registerInfo);
    }
}
