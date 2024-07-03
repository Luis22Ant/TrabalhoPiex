using ApiProjetoIntegrador.Communication.Request.Item;
using ApiProjetoIntegrador.Repositories.ItensRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjetoIntegrador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;

        public ItemController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var itens = await _itemRepository.GetAll();

                if (itens is null)
                    return NotFound();

                return Ok(itens);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpGet]
        [Route("{itemId}")]

        public async Task<IActionResult> GetById([FromRoute] Guid itemId)
        {
            try
            {
                var item = await _itemRepository.GetById(itemId);

                if (item is null)
                    return NotFound();

                return Ok(item);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ItemRequest request)
        {
            try
            {
                var response = await _itemRepository.Create(request);

                if (response is null)
                    return BadRequest();

                return Created("", response);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpDelete]
        [Route("{itemId}")]
        public async Task<IActionResult> Delete([FromRoute] Guid itemId)
        {
            try
            {
                var response = await _itemRepository.Delete(itemId);

                if (!response)
                    return NotFound();

                return Ok(response);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpPut]
        [Route("{itemId}")]
        public async Task<IActionResult> Update([FromRoute] Guid itemId, [FromRoute] ItemRequest request)
        {
            try
            {
                var response = await _itemRepository.Update(itemId, request);

                if (!response)
                    return NotFound();

                return Ok(response);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
