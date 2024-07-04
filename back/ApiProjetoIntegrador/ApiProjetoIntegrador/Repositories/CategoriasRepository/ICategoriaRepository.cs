using ApiProjetoIntegrador.Communication.Request.Categoria;
using ApiProjetoIntegrador.Communication.Request.Doador;
using ApiProjetoIntegrador.Infra.Entities;

namespace ApiProjetoIntegrador.Repositories.CategoriasRepository
{
    public interface ICategoriaRepository
    {
        Task<List<Categoria>> GetAll();

        Task<Categoria?> GetById(Guid id);

        Task<bool> Delete(Guid id);
        Task<bool> Update(Guid id, CategoriaRequest request);
        Task<Categoria> Create(CategoriaRequest request);
    }
}
