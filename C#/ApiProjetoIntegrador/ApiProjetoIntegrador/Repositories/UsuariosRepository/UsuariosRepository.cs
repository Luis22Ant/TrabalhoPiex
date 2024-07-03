using ApiProjetoIntegrador.Communication.Request.Auth;
using ApiProjetoIntegrador.Infra;
using ApiProjetoIntegrador.Infra.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiProjetoIntegrador.Repositories.UsuariosRepository
{
    public class UsuariosRepository : IUsuarioRepository
    {
        private readonly ApiDbContext _context;

        public UsuariosRepository(ApiDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Delete(Guid id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<List<Usuario>> GetAll()
        {
            var usuarios = await _context.Usuarios.AsNoTracking().ToListAsync();

            return usuarios;
        }

        public async Task<Usuario?> GetById(Guid id)
        {
            var usuario = await _context.Usuarios.SingleOrDefaultAsync(u => u.Id == id);

            return usuario;
        }

        public async Task<Usuario> Create(RegisterRequest request)
        {
            Usuario usuario = new Usuario
            {
                Nome = request.Nome,
                Login = request.Login,
                Senha = request.Senha,
                Cpf = request.Cpf,
                Role = request.Role,
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }

        public async Task<bool> Update(Guid id, RegisterRequest request)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario != null)
            {
                usuario.Login = request.Login;
                usuario.Nome = request.Nome;
                usuario.Cpf = request.Cpf;
                usuario.Role = request.Role;
                usuario.Senha = request.Senha;

                _context.Usuarios.Update(usuario);
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}
