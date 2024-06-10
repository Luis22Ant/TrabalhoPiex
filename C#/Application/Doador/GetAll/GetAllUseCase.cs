using Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Communication.Response;
using Microsoft.EntityFrameworkCore;
using Exception;

namespace Application.Doador.GetAll
{
    public class GetAllUseCase
    {
        private readonly ApiPiexDbContext _dbContext;

        public GetAllUseCase()
        {
            _dbContext = new ApiPiexDbContext();
        }

        public async Task<ResponseGetAll> Execute()
        {
            var entity = await _dbContext.Doadores.ToListAsync();

            if (entity is null)
            {
                throw new NotFoundException("Nenhum funcionário encontrado!");
            }
            return new ResponseGetAll
            {
                DoadorList = entity
            };
        }
    }
}
