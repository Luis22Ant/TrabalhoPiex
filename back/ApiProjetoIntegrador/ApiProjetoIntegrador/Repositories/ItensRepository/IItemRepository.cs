using ApiProjetoIntegrador.Communication.Request.Item;
using ApiProjetoIntegrador.Infra.Entities;

namespace ApiProjetoIntegrador.Repositories.ItensRepository
{
    public interface IItemRepository
    {
        public Task<List<Item>> GetAll();
        public Task<Item?> GetById(Guid id);
        public Task<bool> Update(Guid id, ItemRequest request);
        public Task<bool> Delete(Guid id);
        public Task<Item> Create(ItemRequest request);
    }
}
