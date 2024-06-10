using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infra.Models;
using Infra;
using Communication.Response;
using Exception;
using Microsoft.EntityFrameworkCore;

namespace Application.Login
{
    public class LoginUseCase
    {
        private readonly ApiPiexDbContext _dbContext;

        public LoginUseCase()
        {
            _dbContext = new ApiPiexDbContext();
        }

        public async Task<ResponseId> Execute(string user, string senha)
        {
            var entity = await _dbContext.Usuarios.FirstOrDefaultAsync(p => p.Login == user && p.Senha == senha);

            if (entity is null)
                throw new UnauthorizedAccess("Login ou senha incorretos!");


            return new ResponseId
            {
                Id = entity.Id
            };
        }
    }
}
