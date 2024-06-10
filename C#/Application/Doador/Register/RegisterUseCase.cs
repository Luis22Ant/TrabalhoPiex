using Infra;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Communication.Response;
using Infra.Models;
using Azure.Core;
using Communication.Request;

namespace Application.Doador.Register
{
    public class RegisterUseCase
    {
        private readonly ApiPiexDbContext _dbContext;

        public RegisterUseCase()
        {
            _dbContext = new ApiPiexDbContext();
        }

        public async Task<ResponseId> Execute(DoadorRequest request)
        {
            var entity = new Infra.Models.Doador
            {    
                Cpf = request.Cpf,
                Data = request.Data,
                itemDoado = request.itemDoado,
                Nome = request.Nome

            };
            await _dbContext.Doadores.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return new ResponseId
            {
                Id = entity.Id
            };
        }
    }
}
