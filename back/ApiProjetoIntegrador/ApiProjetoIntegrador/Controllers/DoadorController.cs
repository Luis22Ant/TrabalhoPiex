using ApiProjetoIntegrador.Communication.Request.Doador;
using ApiProjetoIntegrador.Repositories.DoadoresRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjetoIntegrador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoadorController : ControllerBase
    {
        private readonly IDoadorRepository _doadorRepository;

        public DoadorController(IDoadorRepository doadorRepository)
        {
            _doadorRepository = doadorRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DoadorRequest request)
        {
            try
            {
                var response = await _doadorRepository.Create(request);

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
                var response = await _doadorRepository.GetAll();

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
        [Route("{doadorId}")]
        public async Task<IActionResult> GetById([FromRoute] Guid doadorId)
        {
            try
            {
                var response = await _doadorRepository.GetById(doadorId);

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
        [Route("{doadorId}")]
        public async Task<IActionResult> Delete([FromRoute] Guid doadorId)
        {
            try
            {
                var response = await _doadorRepository.Delete(doadorId);

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
        [Route("{doadorId}")]
        public async Task<IActionResult> Update([FromRoute] Guid doadorId, [FromBody] DoadorRequest request)
        {
            try
            {
                var response = await _doadorRepository.Update(doadorId, request);

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
