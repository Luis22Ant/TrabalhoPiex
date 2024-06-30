using ApiProjetoIntegrador;
using ApiProjetoIntegrador.Infra.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiWithJwt.Services
{
    public class TokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateToken(Usuario user)
        {
            var handler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("JwtSettings:SecretKey").Value);

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = GenerateClaims(user),
                SigningCredentials = credentials,
                Expires = DateTime.UtcNow.AddHours(8),
            };

            var token = handler.CreateToken(tokenDescriptor);

            return handler.WriteToken(token);
        }


        private static ClaimsIdentity GenerateClaims(Usuario user)
        {
            var ci = new ClaimsIdentity();

            ci.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            ci.AddClaim(new Claim(ClaimTypes.Name, user.Nome));
            ci.AddClaim(new Claim(ClaimTypes.Role, user.Role.ToString()));
            return ci;
        }
    }
}

