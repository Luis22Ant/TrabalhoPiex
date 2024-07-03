using ApiProjetoIntegrador.Communication.Request.Auth;
using ApiProjetoIntegrador.Repositories.UsuariosRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjetoIntegrador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioRepository _usuariosRepository;

        public UsuarioController(IUsuarioRepository usuariosRepository)
        {
            _usuariosRepository = usuariosRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _usuariosRepository.GetAll();

                if (response is null)
                    return NotFound();

                return Ok(response);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Entre em contato!");
            }

        }

        [HttpGet]
        [Route("{usuarioId}")]
        public async Task<IActionResult> GetById([FromRoute] Guid usuarioId)
        {
            try
            {
                var response = await _usuariosRepository.GetById(usuarioId);

                if (response is null)
                    return NotFound();

                return Ok(response);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Entre em contato!");
            }
        }

        [HttpDelete]
        [Route("{usuarioId}")]
        public async Task<IActionResult> Delete([FromRoute] Guid usuarioId)
        {
            try
            {
                var response = await _usuariosRepository.Delete(usuarioId);

                if (!response)
                    return NotFound();

                return Ok(response);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Entre em contato!");
            }
        }

        [HttpPut]
        [Route("{usuarioId}")]
        public async Task<IActionResult> Update([FromRoute] Guid usuarioId, [FromBody] RegisterRequest request)
        {
            try
            {
                var response = await _usuariosRepository.Update(usuarioId, request);

                if (!response)
                    return NotFound();

                return Ok(response);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Entre em contato!");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RegisterRequest request)
        {
            try
            {
                var response = await _usuariosRepository.Create(request);

                if (response is null)
                    return BadRequest();

                return Created("", response);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Entre em contato!");
            }
        }
    }
}
