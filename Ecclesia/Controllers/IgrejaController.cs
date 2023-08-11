using Ecclesia.Api.Dto;
using Ecclesia.Domain;
using Ecclesia.Service.Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Ecclesia.Api.Controllers
{
    [ApiController, Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class IgrejaController : Controller
    {
        private readonly IIgrejaService _service;

        public IgrejaController(IIgrejaService service)
        {
            _service = service;
        }

        [HttpPost, Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("api/[controller]")]
        public async Task<IActionResult> CadastrarIgreja([FromBody] IgrejaInsertDto IgrejaDto)
        {
            try
            {
                await _service.InsertIgreja(
                new Igreja
                {
                    Nome = IgrejaDto.Nome,
                    Logradouro = IgrejaDto.Logradouro,
                    Numero = IgrejaDto.Numero,
                    Complemento= IgrejaDto.Complemento,
                    Bairro= IgrejaDto.Bairro,
                    Cidade= IgrejaDto.Cidade,
                    Uf= IgrejaDto.Uf,
                    UsuarioCriacao = IgrejaDto.Usuario,
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
        public async Task<IActionResult> AtualizarIgrejaUsuario([FromBody] IgrejaUpdateDto IgrejaDto)
        {
            try
            {
                await _service.UpdateIgreja(
                new Igreja
                {
                    Id = IgrejaDto.Id,
                    Nome = IgrejaDto.Nome,
                    Numero = IgrejaDto.Numero,
                    UsuarioUltimaAlteracao = IgrejaDto.Usuario,
                    Status = IgrejaDto.Status
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
        public async Task<IActionResult> ConsultarIgreja(int id)
        {
            try
            {
                var igreja = await _service.GetIgreja(id);
                return Ok(igreja);
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
        [Route("api/[controller]/GetAllIgrejasByDescricao/{descricao}")]
        public async Task<IActionResult> BuscarIgreja(string nome)
        {
            try
            {
                var igreja = await _service.GetAllIgrejasByNome(nome);
                return Ok(igreja);
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
        public async Task<IActionResult> DeletarIgreja(int id)
        {
            try
            {
                await _service.DeleteIgreja(id);
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
