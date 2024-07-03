using ApiProjetoIntegrador.Communication.Request.Auth;
using ApiProjetoIntegrador.Repositories.Auth;
using ApiWithJwt.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjetoIntegrador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        private readonly TokenService _tokenService;

        public AuthController(IAuthRepository authRepository, TokenService tokenService)
        {
            _authRepository = authRepository;
            _tokenService = tokenService;
        }

        [HttpPost("/auth")]
        public async Task<IActionResult> Auth([FromBody] AuthRequest request)
        {
            var user = await _authRepository.Auth(request);

            if (user is null)
                return NotFound();

            var token = _tokenService.GenerateToken(user);

            return Ok(token);
        }

        [HttpPost("/register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var user = await _authRepository.Register(request);

            if (user is null)
                return BadRequest();

            return Created("Criado com sucesso",user);
        }
    }
}
