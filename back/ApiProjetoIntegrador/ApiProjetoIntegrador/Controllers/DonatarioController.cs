using ApiProjetoIntegrador.Communication.Request.Donatario;
using ApiProjetoIntegrador.Repositories.DonatariosRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjetoIntegrador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonatarioController : ControllerBase
    {
        private readonly IDonatarioRepository _donatarioRepository;

        public DonatarioController(IDonatarioRepository donatarioRepository)
        {
            _donatarioRepository = donatarioRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DonatarioRequest request)
        {
            var response = await _donatarioRepository.Create(request);

            if (response is null)
                return BadRequest();

            return Created("", response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _donatarioRepository.GetAll();

            if (response is null)
                return NotFound();

            return Ok(response);
        }

        [HttpGet]
        [Route("{donatarioId}")]
        public async Task<IActionResult> GetById([FromRoute] Guid donatarioId)
        {
            var response = await _donatarioRepository.GetById(donatarioId);

            if (response is null)
                return NotFound();

            return Ok(response);
        }

        [HttpDelete]
        [Route("{donatarioId}")]
        public async Task<IActionResult> Delete([FromRoute] Guid donatarioId)
        {
            var response = await _donatarioRepository.Delete(donatarioId);

            if (!response)
                return NotFound();

            return NoContent();
        }

        [HttpPut]
        [Route("{donatarioId}")]
        public async Task<IActionResult> Update([FromRoute] Guid donatarioId, [FromBody] DonatarioRequest request)
        {
            var response = await _donatarioRepository.Update(donatarioId, request);

            if (!response)
                return NotFound();

            return NoContent();
        }
    }
}
