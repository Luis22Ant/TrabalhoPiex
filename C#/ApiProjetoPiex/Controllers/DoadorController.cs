using Application.Doador.GetAll;
using Application.Doador.Register;
using Application.Doador.Update;
using Infra.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Communication.Request;
using Azure.Core;

namespace ApiProjetoPiex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoadorController : ControllerBase
    {
        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var useCase = new GetAllUseCase();

            var response = await useCase.Execute();

            if(response is null)
                return NotFound();

            return Ok(response);
        }

        [HttpPost]

        public async Task<IActionResult> Register([FromBody] DoadorRequest request)
        {
            var useCase = new RegisterUseCase();
            var response = await useCase.Execute(request);

            if(response is null)
                return NotFound();

            return Ok(response);
        }

        [HttpPut]
        [Route("{idDoador}")]

        public async Task<IActionResult> Update([FromRoute] Guid idDoador, [FromBody] DoadorRequest request)
        {
            var useCase = new UpdateUseCase();
            var response = await useCase.Execute(idDoador, request);

            if (response is null)
                return NotFound();

            return Ok(response);
        }
    }
}
