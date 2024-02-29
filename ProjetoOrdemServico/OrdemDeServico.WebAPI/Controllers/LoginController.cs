using Microsoft.AspNetCore.Mvc;
using OrdemDeServico.Application.InputModels;
using OrdemDeServico.Application.Services.Interfaces;
using OrdemDeServico.Infra.Auth;


namespace OrdemDeServico.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v0.1/")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] NewLoginInputModel loginInput)
        {
            var authenticatedUser = _loginService.Authenticate(loginInput);
            return Ok(authenticatedUser);
        }
    }
}
