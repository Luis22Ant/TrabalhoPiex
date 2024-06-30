using ApiProjetoIntegrador.Communication.Request.Auth;
using ApiProjetoIntegrador.Infra.Entities;

namespace ApiProjetoIntegrador.Repositories.Auth
{
    public interface IAuthRepository
    {
        Task<Usuario?> Auth(AuthRequest request);
        Task<Usuario?> Register(RegisterRequest request);
    }
}
