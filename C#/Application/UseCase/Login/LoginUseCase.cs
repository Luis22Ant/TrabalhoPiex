using ApiPiex.Infra;
using Communication.Response;
using ApiPiex.Exception;
using Microsoft.EntityFrameworkCore;


namespace ApiPiex.Application.UseCase.Login
{
    public class LoginUseCase
    {
        private readonly ProjetoDbContext _dbContext;

        public LoginUseCase()
        {
            _dbContext = new ProjetoDbContext();
        }

        public async Task<ResponseLogin> Execute(string email, string senha)
        {
            var entity = await _dbContext.Usuarios.FirstOrDefaultAsync(p => p.Email == email && p.Senha == senha);

            if (entity is null)
                throw new UnauthorizedAccess("Login ou senha incorretos!");


            return new ResponseLogin
            {
                Id = entity.Id
            };
        }
    }
}
