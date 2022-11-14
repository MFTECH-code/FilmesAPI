using Alura.UsuariosAPI.Data.Requests;
using Alura.UsuariosAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace Alura.UsuariosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public IActionResult LogaUsuario([FromBody] LoginRequest request)
        {
            Result result = _loginService.LogaUsuario(request);
            if (result.IsFailed) return Unauthorized(result.Errors);
            return Ok(new { Token = result.Successes.First().Message });
        }
    }
}
