using Ecclesia.Api.Dto;
using Ecclesia.Domain;
using Ecclesia.Service.Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecclesia.Api.Controllers
{
    public class DizimoController : ControllerBase
    {
        private readonly IDizimoService _service;

        public DizimoController(IDizimoService service)
        {
            _service = service;
        }

        [HttpPost, Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("api/[controller]")]
        public async Task<IActionResult> Cadastrar([FromBody] DizimoInsertDto dto)
        {
            try
            {
                await _service.Insert(
                new Dizimo
                {
                    Reuniao = dto.Reuniao,
                    Membro = dto.Membro,
                    Valor = dto.Valor,
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
        public async Task<IActionResult> Atualizar([FromBody] DizimoUpdateDto dto)
        {
            try
            {
                await _service.Update(
                new Dizimo
                {
                    Id = dto.Id,
                    Valor = dto.Valor,
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
        [Route("api/[controller]/GetAllByReuniao/{reuniao}")]
        public async Task<IActionResult> Buscar(int reuniao)
        {
            try
            {
                return Ok(await _service.GetAll(reuniao));
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
        [Route("api/[controller]/GetAll/{membro}/{dataInicio}/{dataFim}")]
        public async Task<IActionResult> Buscar(int membro, DateTime dataInicio, DateTime dataFim)
        {
            try
            {
                return Ok(await _service.GetAll(membro, dataInicio, dataFim));
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
