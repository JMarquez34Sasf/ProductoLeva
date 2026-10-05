using ProductoLeva.Models;

namespace ProductoLeva.Interfaces
{
    public interface IAuth
    {
        Task<Usuario?> GetUser(string username);
        Task<Usuario> Register(Usuario user);
    }
}
