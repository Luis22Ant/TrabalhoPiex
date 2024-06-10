using Azure;

using Microsoft.AspNetCore.Mvc;
using ApiPiex.Application.UseCase.Login;


namespace ApiPiex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> Login(string login, string senha)
        {
            var useCase = new LoginUseCase();

            var response = await useCase.Execute(login, senha);

            if(response is null)
                return NotFound();


            return Ok(login);
        }
    }
}
