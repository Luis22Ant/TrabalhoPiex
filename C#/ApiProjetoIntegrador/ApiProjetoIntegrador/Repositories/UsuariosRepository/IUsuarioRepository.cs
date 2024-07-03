using ApiProjetoIntegrador.Communication.Request.Auth;
using ApiProjetoIntegrador.Infra.Entities;

namespace ApiProjetoIntegrador.Repositories.UsuariosRepository
{
    public interface IUsuarioRepository
    {
        public Task<List<Usuario>> GetAll();
        public Task<Usuario?> GetById(Guid id);
        public Task<bool> Update(Guid id, RegisterRequest request);
        public Task<bool> Delete(Guid id);
        public Task<Usuario> Create(RegisterRequest request);

    }
}
