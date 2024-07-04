using ApiProjetoIntegrador.Infra.Entities;
using ApiProjetoIntegrador.Infra;
using Microsoft.EntityFrameworkCore;
using ApiProjetoIntegrador.Communication.Request.ItemDoado;

namespace ApiProjetoIntegrador.Repositories.ItensDoadosRepository
{
    public class ItemDoadosRepository : IItensDoadosRepository
    {
        private readonly ApiDbContext _context;

        public ItemDoadosRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<ItemDoado?> Create(ItemDoado itemDoado)
        {
            var item = await _context.Itens.FindAsync(itemDoado.ItemId);

            if (item == null || item.Quantidade < itemDoado.Quantidade)
            {
                return null;
            }

            item.DiminuirItem(itemDoado.Quantidade);

            _context.ItensDoados.Add(itemDoado);
            await _context.SaveChangesAsync();

            return itemDoado;
        }

        public async Task<bool> Delete(Guid id)
        {
            var itemDoado = await _context.ItensDoados.FindAsync(id);

            if (itemDoado != null)
            {
                _context.ItensDoados.Remove(itemDoado);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<List<ItemDoado>> GetAll()
        {
            return await _context.ItensDoados.AsNoTracking().ToListAsync();
        }

        public async Task<ItemDoado?> GetById(Guid id)
        {
            return await _context.ItensDoados.AsNoTracking().SingleOrDefaultAsync(d => d.Id == id);
        }

        public async Task<bool> Update(Guid id, ItemDoadoRequest itemDoado)
        {
            var existingItemDoado = await _context.ItensDoados.FindAsync(id);

            if (existingItemDoado != null)
            {
                existingItemDoado.ItemId = itemDoado.ItemId;
                existingItemDoado.DonatarioId = itemDoado.DonatarioId;
                existingItemDoado.DataDoacao = itemDoado.DataDoacao;
                existingItemDoado.Quantidade = itemDoado.Quantidade;
                _context.ItensDoados.Update(existingItemDoado);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
