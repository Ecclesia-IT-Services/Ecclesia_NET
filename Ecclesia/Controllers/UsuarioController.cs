using Domain;
using Ecclesia.Api.Dto;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace Api.Controllers
{
    [ApiController, Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;

        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpPost, Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("api/[controller]")]
        public async Task<IActionResult> CadastrarUsuario([FromBody] UsuarioInsertDto usuarioDto)
        {
            await _service.InsertUsuario(
                new Usuario{
                        Login = usuarioDto.Login,
                        Senha = usuarioDto.Senha,
                        Nome = usuarioDto.Nome,
                        NivelAcesso = usuarioDto.NivelAcesso,
                        UsuarioCriacao = usuarioDto.Usuario
                });
            return Ok(new {Success = true});
        }

        [HttpPut, Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("api/[controller]")]
        public async Task<IActionResult> AtualizarUsuario([FromBody] UsuarioUpdateDto usuarioDto)
        {
            await _service.UpdateUsuario(
                new Usuario {
                        Id = usuarioDto.Id,
                        Senha = usuarioDto.Senha,
                        Nome = usuarioDto.Nome,
                        NivelAcesso = usuarioDto.NivelAcesso,
                        UsuarioUltimaAlteracao = usuarioDto.Usuario,
                        Status = usuarioDto.Status});
            return Ok(new { Success = true });
        }

        [HttpGet, Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> ConsultarUsuario(int id)
        {
            var usuario = await _service.GetUsuario(id);                
            return Ok(usuario);
        }

        [HttpGet, Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("api/[controller]/GetAllByName/{nome}")]
        public async Task<IActionResult> BuscarUsuarios(string nome)
        {
            var usuario = await _service.GetAllUsuariosByName(nome);
            return Ok(usuario);
        }

        [HttpDelete, Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> DeletarUsuario(int id)
        {
            await _service.DeleteUsuario(id);
            return Ok(new { Success = true });
        }
    }
}
