

using Org.BouncyCastle.Crypto.Generators;
using ProductoLeva.Interfaces;
using ProductoLeva.Interfaz;
using ProductoLeva.Models;

namespace AuthApiVideoGame.Services
{
    public class AuthService : IAuthService

    {
        private readonly IAuth authRepository;
        private readonly IJwtService jwtService;
        public AuthService(IAuth authRepository, IJwtService jwtService)
        {
            this.authRepository = authRepository;
            this.jwtService = jwtService;
        }

        public async Task<Usuario> Register(Usuario user)
        {
            var usuarioExistente = await authRepository.GetUser(user.Email);

            if (usuarioExistente != null)
            {
                throw new ArgumentException("El usuario ya existe");
            }
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            return await authRepository.Register(user);
        }
        public async Task<string> Login(string username, string password)
        {
            var usuario = await authRepository.GetUser(username);
            if (username == null)
            {
                throw new ArgumentException("Usuario o contraseña incorrectas");
            }
            var contraseñaCorrecta = BCrypt.Net.BCrypt.Verify(password, usuario.Password);
            if (!contraseñaCorrecta)
            {
                throw new ArgumentException();
            }
            return jwtService.GenerateToken(usuario.Password, usuario.Role);
        }
    }
}
