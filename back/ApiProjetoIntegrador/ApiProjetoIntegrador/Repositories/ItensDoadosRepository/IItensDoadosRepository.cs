using ApiProjetoIntegrador.Communication.Request.ItemDoado;
using ApiProjetoIntegrador.Infra.Entities;

namespace ApiProjetoIntegrador.Repositories.ItensDoadosRepository
{
    public interface IItensDoadosRepository
    {
        Task<ItemDoado?> Create(ItemDoado itemDoado);
        Task<bool> Delete(Guid id);
        Task<List<ItemDoado>> GetAll();
        Task<ItemDoado?> GetById(Guid id);
        Task<bool> Update(Guid id, ItemDoadoRequest itemDoado);
    }
}
