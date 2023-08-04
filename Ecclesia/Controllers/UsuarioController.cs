using Api.Dto;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace Api.Controllers
{
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;

        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> CadastrarUsuario([FromBody] UsuarioDto usuarioDto)
        {
            await _service.InsertUsuario(
                new Usuario(
                        usuarioDto.Id,
                        usuarioDto.Senha,
                        usuarioDto.Nome,
                        usuarioDto.Senha,
                        usuarioDto.NivelAcesso,
                        usuarioDto.DataCriacao,
                        usuarioDto.UsuarioCriacao,
                        usuarioDto.DataUltimaAlteracao,
                        usuarioDto.UsuarioUltimaAlteracao,
                        usuarioDto.Status));
            return Ok(new {Success = true});
        }

        [HttpPut]
        [Route("api/[controller]")]
        public async Task<IActionResult> AtualizarUsuario([FromBody] UsuarioDto usuarioDto)
        {
            await _service.UpdateUsuario(
                new Usuario(
                        usuarioDto.Id,
                        usuarioDto.Senha,
                        usuarioDto.Nome,
                        usuarioDto.Senha,
                        usuarioDto.NivelAcesso,
                        usuarioDto.DataCriacao,
                        usuarioDto.UsuarioCriacao,
                        usuarioDto.DataUltimaAlteracao,
                        usuarioDto.UsuarioUltimaAlteracao,
                        usuarioDto.Status));
            return Ok(new { Success = true });
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> ConsultarUsuario(int id)
        {
            var usuario = await _service.GetUsuario(id);                
            return Ok(usuario);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> DeletarUsuario(int id)
        {
            await _service.DeleteUsuario(id);
            return Ok(new { Success = true });
        }
    }
}
