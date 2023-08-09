using Ecclesia.Api.Dto;
using Ecclesia.Domain;
using Ecclesia.Service.Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers
{
    [ApiController, Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CargoController : ControllerBase
    {
        private readonly ICargoService _service;

        public CargoController(ICargoService service)
        {
            _service = service;
        }

        [HttpPost, Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)] 
        [Route("api/[controller]")]
        public async Task<IActionResult> CadastrarCargo([FromBody] CargoInsertDto cargoDto)
        {
            try
            {
                await _service.InsertCargo(
                new Cargo
                {
                    Descricao = cargoDto.Descricao,
                    UsuarioCriacao = cargoDto.Usuario,
                });

                return Ok(new { Success = true });
            }
            catch(BusinessHttpResponseException ex)
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
        public async Task<IActionResult> AtualizarCargoUsuario([FromBody] CargoUpdateDto cargoDto)
        {
            try
            {
                await _service.UpdateCargo(
                new Cargo
                {
                    Id = cargoDto.Id,
                    Descricao = cargoDto.Descricao,
                    UsuarioUltimaAlteracao = cargoDto.Usuario,
                    Status = cargoDto.Status
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
        public async Task<IActionResult> ConsultarCargo(int id)
        {
            try
            {
                var cargo = await _service.GetCargo(id);
                return Ok(cargo);
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
        [Route("api/[controller]/GetAllCargosByDescricao/{descricao}")]
        public async Task<IActionResult> BuscarCargo(string descricao)
        {
            try
            {
                var cargo = await _service.GetAllCargosByDescricao(descricao);
                return Ok(cargo);
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
        public async Task<IActionResult> DeletarCargo(int id)
        {
            try
            {
                await _service.DeleteCargo(id);
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
