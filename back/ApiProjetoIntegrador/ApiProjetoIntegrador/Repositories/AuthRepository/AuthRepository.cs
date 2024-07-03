using ApiProjetoIntegrador.Communication.Request.Auth;
using ApiProjetoIntegrador.Infra;
using ApiProjetoIntegrador.Infra.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiProjetoIntegrador.Repositories.Auth
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApiDbContext _context;

        public AuthRepository(ApiDbContext context)
        {
            _context = context;
        }
        public async Task<Usuario?> Auth(AuthRequest request)
        {
            var user = await _context.Usuarios.SingleOrDefaultAsync(u => u.Login == request.Login && u.Senha == request.Senha);

            return user;
        }

        public async Task<Usuario?> Register(RegisterRequest request)
        {
            Usuario user = new Usuario
            {
                Login = request.Login,
                Nome = request.Nome,
                Senha = request.Senha,
                Cpf = request.Cpf,
                Role = Role.Usuario
            };

            _context.Usuarios.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }
    }
}
