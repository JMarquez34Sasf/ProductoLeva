
using Microsoft.EntityFrameworkCore;
using ProductoLeva.Data;
using ProductoLeva.Interfaces;
using ProductoLeva.Models;

namespace ProductoLeva.Repositories
{
    public class Auth : IAuth
    {
        private readonly ProductoContext context;

        public Auth(ProductoContext context)
        {
            this.context = context;
        }

        // ================= BUSCAR USUARIO =================

        public async Task<Usuario?> GetUser(string username)
        {
            return await context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == username);
        }

        public Task<Usuario> Login(Usuario UserName)
        {
            throw new NotImplementedException();
        }

        // ================= REGISTRAR =================

        public async Task<Usuario> Register(Usuario user)
        {
            context.Usuarios.Add(user);

            await context.SaveChangesAsync();

            return user;
        }
    }
}