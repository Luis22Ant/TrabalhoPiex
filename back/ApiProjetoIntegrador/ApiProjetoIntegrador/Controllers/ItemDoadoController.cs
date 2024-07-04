using ApiProjetoIntegrador.Communication.Request.ItemDoado;
using ApiProjetoIntegrador.Infra.Entities;
using ApiProjetoIntegrador.Repositories.ItensDoadosRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjetoIntegrador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemDoadoController : ControllerBase
    {
        private readonly IItensDoadosRepository _itemDoadosRepository;

        public ItemDoadoController(IItensDoadosRepository itemDoadosRepository)
        {
            _itemDoadosRepository = itemDoadosRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var itensDoados = await _itemDoadosRepository.GetAll();
            return Ok(itensDoados);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var itemDoado = await _itemDoadosRepository.GetById(id);

            if (itemDoado == null)
            {
                return NotFound();
            }

            return Ok(itemDoado);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ItemDoadoRequest request)
        {
            var itemDoado = new ItemDoado
            {
                Id = Guid.NewGuid(),
                ItemId = request.ItemId,
                DonatarioId = request.DonatarioId,
                DataDoacao = request.DataDoacao,
                Quantidade = request.Quantidade
            };

            var createdItemDoado = await _itemDoadosRepository.Create(itemDoado);

            if (createdItemDoado == null)
            {
                return BadRequest();
            }

            return Created("", createdItemDoado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ItemDoadoRequest request)
        {
            var updated = await _itemDoadosRepository.Update(id, request);

            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _itemDoadosRepository.Delete(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
