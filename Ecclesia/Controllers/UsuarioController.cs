using Domain;
using Ecclesia.Api.Dto;
using Ecclesia.Domain;
using Ecclesia.Service.Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;

        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> CadastrarUsuario([FromBody] UsuarioInsertDto usuarioDto)
        {
            try
            {
                await _service.InsertUsuario(
                    new Usuario
                    {
                        Login = usuarioDto.Login,
                        Senha = usuarioDto.Senha,
                        Nome = usuarioDto.Nome,
                        NivelAcesso = usuarioDto.NivelAcesso,
                        UsuarioCriacao = usuarioDto.Usuario
                    });
                return Ok(new { Success = true });
            }
            catch (BusinessHttpResponseException)
            {
                return Conflict(new { success = false, error = "Esse login já está em uso." });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, error = "Erro interno do servidor" });
            }
        }


        [HttpPut]
        [Route("api/[controller]")]
        public async Task<IActionResult> AtualizarUsuario([FromBody] UsuarioUpdateDto usuarioDto)
        {
            try
            {
                await _service.UpdateUsuario(new Usuario
                {
                    Id = usuarioDto.Id,
                    Senha = usuarioDto.Senha,
                    Nome = usuarioDto.Nome,
                    NivelAcesso = usuarioDto.NivelAcesso,
                    UsuarioUltimaAlteracao = usuarioDto.Usuario,
                    Status = usuarioDto.Status
                });
                return Ok(new { Success = true });
            }
            catch (BusinessHttpResponseException ex)
            {
                return StatusCode((int)ex.Response.StatusCode, new { Success = false, Response = ex.Response });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Error = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> ConsultarUsuario(int id)
        {
            try
            {
                var usuario = await _service.GetUsuario(id);
                return Ok(usuario);
            }
            catch (BusinessHttpResponseException ex)
            {
                return StatusCode((int)ex.Response.StatusCode, new { Success = false, Response = ex.Response });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Error = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/[controller]/GetAllByName/{nome}")]
        public async Task<IActionResult> BuscarUsuarios(string nome)
        {
            try
            {
                var usuarios = await _service.GetAllUsuariosByName(nome);
                return Ok(usuarios);
            }
            catch (BusinessHttpResponseException ex)
            {
                return StatusCode((int)ex.Response.StatusCode, new { Success = false, Response = ex.Response });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Error = ex.Message });
            }
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> DeletarUsuario(int id)
        {
            try
            {
                await _service.DeleteUsuario(id);
                return Ok(new { Success = true });
            }
            catch (BusinessHttpResponseException ex)
            {
                return StatusCode((int)ex.Response.StatusCode, new { Success = false, Response = ex.Response });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Error = ex.Message });
            }
        }
    }
}
