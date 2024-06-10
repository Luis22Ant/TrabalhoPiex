using Application.Login;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjetoPiex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> Login(string login,string senha)
        {
            var useCase = new LoginUseCase();

            var response = await useCase.Execute(login,senha);

            if(response is null)
                return NotFound();

            return Ok(response);
        }
    }
}
