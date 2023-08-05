using Api.Dto;
using Domain;
using Ecclesia.Api.Dto;
using Ecclesia.Domain;
using Ecclesia.Service.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace Api.Controllers
{
    [ApiController]
    public class CargoController : ControllerBase
    {
        private readonly ICargoService _service;

        public CargoController(ICargoService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> CadastrarCargo([FromBody] CargoInsertDto cargoDto)
        {
            await _service.InsertCargo(
                new Cargo
                {
                    Descricao = cargoDto.Descricao,
                    UsuarioCriacao = cargoDto.Usuario,
                });
                        
            return Ok(new { Success = true });
        }

        [HttpPut]
        [Route("api/[controller]")]
        public async Task<IActionResult> AtualizarCargoUsuario([FromBody] CargoUpdateDto cargoDto)
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

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> ConsultarCargo(int id)
        {
            var cargo = await _service.GetCargo(id);
            return Ok(cargo);
        }

        [HttpGet]
        [Route("api/[controller]/GetAllCargosByDescricao/{descricao}")]
        public async Task<IActionResult> BuscarCargo(string descricao)
        {
            var cargo = await _service.GetAllCargosByDescricao(descricao);
            return Ok(cargo);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> DeletarCargo(int id)
        {
            await _service.DeleteCargo(id);
            return Ok(new { Success = true });
        }
    }
}
