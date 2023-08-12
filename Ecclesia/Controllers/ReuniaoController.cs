using Ecclesia.Api.Dto;
using Ecclesia.Domain;
using Ecclesia.Service.Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecclesia.Api.Controllers
{
    [ApiController, Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ReuniaoController : ControllerBase
    {
        private readonly IReuniaoService _service;

        public ReuniaoController(IReuniaoService service)
        {
            _service = service;
        }

        [HttpPost, Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("api/[controller]")]
        public async Task<IActionResult> CadastrarReuniao([FromBody] ReuniaoInsertDto reuniaoDto)
        {
            try
            {
                await _service.Insert(
                new Reuniao
                {
                    Igreja = reuniaoDto.Igreja,
                    Celula = reuniaoDto.Celula,
                    Data = reuniaoDto.Data,
                    Pregador = reuniaoDto.Pregador,
                    QuantidadeParticipantes = reuniaoDto.QuantidadeParticipantes,
                    QuantidadeVisitantes = reuniaoDto.QuantidadeVisitantes,
                    QuantidadeCriancas = reuniaoDto.QuantidadeCriancas,
                    ValorOfertas = reuniaoDto.ValorOfertas,
                    ValorOfertasEspeciais = reuniaoDto.ValorOfertasEspeciais,
                    ValorPrimicias = reuniaoDto.ValorPrimicias,
                    UsuarioCriacao = reuniaoDto.Usuario,
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
        public async Task<IActionResult> AtualizarREeuniao([FromBody] ReuniaoUpdateDto reuniaoDto)
        {
            try
            {
                await _service.Update(
                new Reuniao
                {
                    Id = reuniaoDto.Id,
                    Pregador = reuniaoDto.Pregador,
                    QuantidadeParticipantes = reuniaoDto.QuantidadeParticipantes,
                    QuantidadeVisitantes = reuniaoDto.QuantidadeVisitantes,
                    QuantidadeCriancas = reuniaoDto.QuantidadeCriancas,
                    ValorOfertas = reuniaoDto.ValorOfertas,
                    ValorOfertasEspeciais = reuniaoDto.ValorOfertasEspeciais,
                    ValorPrimicias = reuniaoDto.ValorPrimicias,
                    UsuarioUltimaAlteracao = reuniaoDto.Usuario,
                    Status = reuniaoDto.Status,
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
        public async Task<IActionResult> ConsultarReuniao(int id)
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
        [Route("api/[controller]/GetAllByIgreja/{dataInicio}/{dataFim}/{igreja}")]
        public async Task<IActionResult> BuscarReuniaoByIgreja(DateTime dataInicio, DateTime dataFim, int igreja)
        {
            try
            {
                return Ok(await _service.GetAllByIgreja(dataInicio, dataFim, igreja));
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
        [Route("api/[controller]/GetAllByCelula/{dataInicio}/{dataFim}/{celula}")]
        public async Task<IActionResult> BuscarReuniaoByCelula(DateTime dataInicio, DateTime dataFim, int celula)
        {
            try
            {
                return Ok(await _service.GetAllByCelula(dataInicio, dataFim, celula));
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
        public async Task<IActionResult> DeletarReuniao(int id)
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
