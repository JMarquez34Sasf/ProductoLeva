
using Microsoft.IdentityModel.Tokens;
using ProductoLeva.Interfaz;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthApiVideoGame.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration configuration;

        public JwtService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string GenerateToken(string username, string Role)
        {
            var key = configuration["Jwt:Key"];
            var issuer = configuration["Jwt:Iusser"];
            var audience = configuration["Jwt:Audience"];

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, Role)
            };

            var securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(key!));

            var credentials = new SigningCredentials(
                securityKey,
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
