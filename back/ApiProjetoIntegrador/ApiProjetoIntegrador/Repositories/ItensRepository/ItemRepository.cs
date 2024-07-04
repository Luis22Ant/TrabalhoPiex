using ApiProjetoIntegrador.Communication.Request.Item;
using ApiProjetoIntegrador.Infra;
using ApiProjetoIntegrador.Infra.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiProjetoIntegrador.Repositories.ItensRepository
{
    public class ItemRepository : IItemRepository
    {
        private readonly ApiDbContext _context;

        public ItemRepository(ApiDbContext context)
        {
            _context = context;
        }
        public async Task<Item> Create(ItemRequest request)
        {
            var item = new Item
            {
                Nome = request.Nome,
                Descricao = request.Descricao,
                Quantidade = request.Quantidade,
                DataDoacao = request.DataDoacao,
                CategoriaId = request.CategoriaId,
                DoadorId = request.DoadorId,
            };

            _context.Itens.Add(item);
            await _context.SaveChangesAsync();

            return item;
        }

        public async Task<bool> Delete(Guid id)
        {
            var item = await _context.Itens.FindAsync(id);

            if (item != null)
            {
                _context.Itens.Remove(item);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<List<Item>> GetAll()
        {
            var itens = await _context.Itens.AsNoTracking().ToListAsync();
            return itens;
        }

        public async Task<Item?> GetById(Guid id)
        {
            var item = await _context.Itens.AsNoTracking().SingleOrDefaultAsync(i => i.Id == id);

            return item;
        }

        public async Task<bool> Update(Guid id, ItemRequest request)
        {
            var item = await _context.Itens.FindAsync(id);

            if (item != null)
            {
                item.Descricao = request.Descricao;
                item.DataDoacao = DateTime.Now;
                item.CategoriaId = request.CategoriaId;
                item.DoadorId = request.DoadorId;
                item.Quantidade = request.Quantidade;

                _context.Itens.Update(item);
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}
