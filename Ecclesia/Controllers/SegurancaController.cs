using Domain;
using Ecclesia.Api.Dto;
using Ecclesia.Domain;
using Ecclesia.Service.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
            try
            {
                var usuario = new Usuario { Login = login.UserName, Senha = login.Password };
                if (await _service.ValidarUsuario(usuario))
                {
                    var tokenString = _service.GerarTokenJwt();
                    return Ok(new { Sucess = true, token = tokenString });
                }
                else
                {
                    throw new BusinessHttpResponseException(Messages.Message(HttpStatusCode.Unauthorized));
                }
            }catch (BusinessHttpResponseException ex)
            {
                return StatusCode((int)ex.Response.StatusCode, new { Succes = false, Response = ex.Response});
            }catch (Exception ex)
            {
                return BadRequest(new { Succes = false, Error = ex.Message });
            } 
        }
    }
}
