using ApiProjetoIntegrador.Communication.Request.Doador;
using ApiProjetoIntegrador.Communication.Request.Donatario;
using ApiProjetoIntegrador.Infra.Entities;

namespace ApiProjetoIntegrador.Repositories.DonatariosRepository;

public interface IDonatarioRepository
{
    Task<List<Donatario>> GetAll();

    Task<Donatario?> GetById(Guid id);

    Task<bool> Delete(Guid id);
    Task<bool> Update(Guid id, DonatarioRequest request);
    Task<Donatario> Create(DonatarioRequest request);
}
