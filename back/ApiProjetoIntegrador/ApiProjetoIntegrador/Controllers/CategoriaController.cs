using ApiProjetoIntegrador.Communication.Request.Categoria;
using ApiProjetoIntegrador.Communication.Request.Doador;
using ApiProjetoIntegrador.Repositories.CategoriasRepository;
using ApiProjetoIntegrador.Repositories.DoadoresRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjetoIntegrador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoriaRequest request)
        {
            try
            {
                var response = await _categoriaRepository.Create(request);

                if (response is null)
                    return BadRequest();

                return Created("", response);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _categoriaRepository.GetAll();

                if (response is null)
                    return NotFound();

                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("{categoriaId}")]
        public async Task<IActionResult> GetById([FromRoute] Guid categoriaId)
        {
            try
            {
                var response = await _categoriaRepository.GetById(categoriaId);

                if (response is null)
                    return NotFound();

                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        [Route("{categoriaId}")]
        public async Task<IActionResult> Delete([FromRoute] Guid categoriaId)
        {
            try
            {
                var response = await _categoriaRepository.Delete(categoriaId);

                if (!response)
                    return NotFound();

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        [Route("{categoriaId}")]
        public async Task<IActionResult> Update([FromRoute] Guid categoriaId, [FromBody] CategoriaRequest request)
        {
            try
            {
                var response = await _categoriaRepository.Update(categoriaId, request);

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
