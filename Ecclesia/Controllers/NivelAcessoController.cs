using Ecclesia.Api.Dto;
using Ecclesia.Domain;
using Ecclesia.Service.Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecclesia.Api.Controllers
{
    public class NivelAcessoController : ControllerBase
    {
        private readonly INivelAcessoService _service;

        public NivelAcessoController(INivelAcessoService service)
        {
            _service = service;
        }

        [HttpPost, Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("api/[controller]")]
        public async Task<IActionResult> Cadastrar([FromBody] NivelAcessoInsertDto dto)
        {
            try
            {
                await _service.Insert(
                new NivelAcesso
                {
                    Descricao = dto.Descricao,
                    UsuarioCriacao = dto.Usuario
                });

                return Ok(new { Success = true });
            }
            catch (BusinessHttpResponseException ex)
            {
                return StatusCode((int)ex.Response.StatusCode, new { Succes = false, Response = ex.Response });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Succes = false, Error = ex.Message });
            }
        }

        [HttpPut, Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("api/[controller]")]
        public async Task<IActionResult> Atualizar([FromBody] NivelAcessoUpdateDto dto)
        {
            try
            {
                await _service.Update(
                new NivelAcesso
                {
                    Id = dto.Id,
                    Descricao = dto.Descricao,
                    UsuarioUltimaAlteracao = dto.Usuario,
                    Status = dto.Status,
                });
                return Ok(new { Success = true });
            }
            catch (BusinessHttpResponseException ex)
            {
                return StatusCode((int)ex.Response.StatusCode, new { Succes = false, Response = ex.Response });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Succes = false, Error = ex.Message });
            }
        }

        [HttpGet, Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> Consultar(int id)
        {
            try
            {
                return Ok(await _service.Get(id));
            }
            catch (BusinessHttpResponseException ex)
            {
                return StatusCode((int)ex.Response.StatusCode, new { Succes = false, Response = ex.Response });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Succes = false, Error = ex.Message });
            }
        }

        [HttpGet, Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("api/[controller]/GetAll/{descricao}")]
        public async Task<IActionResult> Buscar(string descricao)
        {
            try
            {
                return Ok(await _service.GetAll(descricao));
            }
            catch (BusinessHttpResponseException ex)
            {
                return StatusCode((int)ex.Response.StatusCode, new { Succes = false, Response = ex.Response });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Succes = false, Error = ex.Message });
            }
        }

        [HttpDelete, Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            try
            {
                await _service.Delete(id);
                return Ok(new { Success = true });
            }
            catch (BusinessHttpResponseException ex)
            {
                return StatusCode((int)ex.Response.StatusCode, new { Succes = false, Response = ex.Response });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Succes = false, Error = ex.Message });
            }
        }
    }
}