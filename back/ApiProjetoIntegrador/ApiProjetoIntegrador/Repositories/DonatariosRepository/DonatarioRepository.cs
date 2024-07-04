using ApiProjetoIntegrador.Communication.Request.Donatario;
using ApiProjetoIntegrador.Infra;
using ApiProjetoIntegrador.Infra.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiProjetoIntegrador.Repositories.DonatariosRepository
{
    public class DonatarioRepository : IDonatarioRepository
    {

        private readonly ApiDbContext _context;

        public DonatarioRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<Donatario> Create(DonatarioRequest request)
        {
            Donatario donatario = new Donatario
            {
                Nome = request.Nome,
                Cpf = request.Cpf,
            };

            _context.Donatarios.Add(donatario);
            await _context.SaveChangesAsync();

            return donatario;
        }

        public async Task<bool> Delete(Guid id)
        {
            var donatario = await _context.Donatarios.FindAsync(id);

            if (donatario != null)
            {
                _context.Donatarios.Remove(donatario);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<List<Donatario>> GetAll()
        {
            var donatarios = await _context.Donatarios.AsNoTracking().ToListAsync();

            return donatarios;
        }

        public async Task<Donatario?> GetById(Guid id)
        {
            var donatario = await _context.Donatarios.AsNoTracking().SingleOrDefaultAsync(d => d.Id == id);

            return donatario;
        }

        public async Task<bool> Update(Guid id, DonatarioRequest request)
        {
            var donatario = await _context.Donatarios.FindAsync(id);

            if (donatario != null)
            {
                donatario.Nome = request.Nome;
                donatario.Cpf = request.Cpf;
                _context.Donatarios.Update(donatario);
                await _context.SaveChangesAsync(true);
                return true;
            }
            return false;
        }
    }
}
