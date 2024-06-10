using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPiex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        [HttpPost]
        public IActionResult Login(string login,string senha)
        {


            return Ok(login);
        }
    }
}
