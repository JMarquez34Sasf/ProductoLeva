using ProductoLeva.Models;

namespace ProductoLeva.Interfaces
{
    public interface IAuthService
    {
        Task<Usuario> Register(Usuario user);
        Task<string> Login(string username, string password);

    }
}
