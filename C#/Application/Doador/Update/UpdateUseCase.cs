using Communication.Request;
using Communication.Response;
using Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Doador.Update
{
    public class UpdateUseCase
    {
        private readonly ApiPiexDbContext _dbContext;

        public UpdateUseCase()
        {
            _dbContext = new ApiPiexDbContext();
        }

        public async Task<ResponseId> Execute(Guid id,DoadorRequest request)
        {
            var entity = await _dbContext.Doadores.FindAsync(id);

            entity.Nome = request.Nome;
            entity.Cpf = request.Cpf;
            entity.Data = request.Data;
            entity.itemDoado = request.itemDoado;

            _dbContext.Doadores.Update(entity);
            await _dbContext.SaveChangesAsync();

            return new ResponseId
            {
                Id = id
            };
        }
    }
}
