using ApiProjetoIntegrador.Communication.Request.Categoria;
using ApiProjetoIntegrador.Infra;
using ApiProjetoIntegrador.Infra.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiProjetoIntegrador.Repositories.CategoriasRepository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly ApiDbContext _context;

        public CategoriaRepository(ApiDbContext context)
        {
            _context = context;
        }
        public async Task<Categoria> Create(CategoriaRequest request)
        {
            Categoria doador = new Categoria
            {
                Nome = request.Nome,
            };

            _context.Categorias.Add(doador);
            await _context.SaveChangesAsync();

            return doador;
        }

        public async Task<bool> Delete(Guid id)
        {
            var categoria = await _context.Categorias.FindAsync(id);

            if (categoria != null)
            {
                _context.Categorias.Remove(categoria);
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<List<Categoria>> GetAll()
        {
            var categorias = await _context.Categorias.AsNoTracking().ToListAsync();

            return categorias;
        }

        public async Task<Categoria?> GetById(Guid id)
        {
            var categoria = await _context.Categorias.AsNoTracking().SingleOrDefaultAsync(d => d.Id == id);

            return categoria;
        }

        public async Task<bool> Update(Guid id, CategoriaRequest request)
        {
            var categoria = await _context.Categorias.FindAsync(id);

            if (categoria != null)
            {
                categoria.Nome = request.Nome;

                _context.Categorias.Update(categoria);
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}
