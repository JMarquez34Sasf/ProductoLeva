

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductoLeva.Interfaces;
using ProductoLeva.Models;

namespace AuthApiVideoGame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;
        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] register dto)
        {
            var user = new Usuario
            {
                Email = dto.Email,
                Password = dto.Password
            };
            var usuarioRegistrado = await authService.Register(user);
            var respuesta = new ResponseGenerico<string>
            {
                codigo = 201,
                message = "Usuario Creado",
                response = usuarioRegistrado.Email
            };
            return StatusCode(201, respuesta);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] Login dto)
        {
            var token = await authService.Login(dto.Email, dto.Password);
            var respuesta = new ResponseGenerico<string>
            {
                codigo = 200,
                message = "Login Exitoso",
                response = token
            };
            return Ok(respuesta);
        }


    }
}
