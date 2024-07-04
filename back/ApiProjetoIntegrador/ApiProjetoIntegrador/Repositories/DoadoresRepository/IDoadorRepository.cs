using ApiProjetoIntegrador.Communication.Request.Doador;
using ApiProjetoIntegrador.Infra.Entities;

namespace ApiProjetoIntegrador.Repositories.DoadoresRepository
{
    public interface IDoadorRepository
    {
        Task<List<Doador>> GetAll();

        Task<Doador?> GetById(Guid id);

        Task<bool> Delete(Guid id);
        Task<bool> Update(Guid id, DoadorRequest request);
        Task<Doador> Create(DoadorRequest request);
    }
}
