using Domain;
using Ecclesia.Api.Dto;
using Ecclesia.Service.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Api.Controllers
{
    [ApiController]
    public class SegurancaController : ControllerBase
    {
        private readonly ISegurancaService _service;
        public SegurancaController(ISegurancaService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> Login([FromBody] LoginDto login)
        {
            var usuario = new Usuario { Login = login.UserName, Senha = login.Password };
            bool resultado = await _service.ValidarUsuario(usuario);
            if (resultado)
            {
                var tokenString = _service.GerarTokenJwt();
                return Ok(new { token = tokenString });
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
