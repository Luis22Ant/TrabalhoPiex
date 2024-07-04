using ApiProjetoIntegrador.Communication.Request.Doador;
using ApiProjetoIntegrador.Infra;
using ApiProjetoIntegrador.Infra.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiProjetoIntegrador.Repositories.DoadoresRepository
{
    public class DoadorRepository : IDoadorRepository
    {
        private readonly ApiDbContext _context;

        public DoadorRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<Doador> Create(DoadorRequest request)
        {
            Doador doador = new Doador
            {
                Nome = request.Nome,
                Cpf = request.Cpf,
            };

            _context.Doadores.Add(doador);
            await _context.SaveChangesAsync();

            return doador;
        }

        public async Task<bool> Delete(Guid id)
        {
            var doador = await _context.Doadores.FindAsync(id);

            if (doador != null)
            {
                _context.Doadores.Remove(doador);
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<List<Doador>> GetAll()
        {
            var doadores = await _context.Doadores.AsNoTracking().ToListAsync();

            //var doadores = await _context.Doadores.Include(d => d.Items).AsNoTracking().ToListAsync(); para incluir os itens que cada pessoa doou

            return doadores;
        }

        public async Task<Doador?> GetById(Guid id)
        {
            var doador = await _context.Doadores.AsNoTracking().SingleOrDefaultAsync(d => d.Id == id);

            return doador;
        }

        public async Task<bool> Update(Guid id, DoadorRequest request)
        {
            var doador = await _context.Doadores.FindAsync(id);

            if (doador != null)
            {
                doador.Nome = request.Nome;
                doador.Cpf = request.Cpf;

                _context.Doadores.Update(doador);
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}
