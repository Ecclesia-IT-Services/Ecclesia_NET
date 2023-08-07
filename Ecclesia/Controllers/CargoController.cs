﻿using Ecclesia.Api.Dto;
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
            await _service.InsertCargo(
                new Cargo
                {
                    Descricao = cargoDto.Descricao,
                    UsuarioCriacao = cargoDto.Usuario,
                });
                        
            return Ok(new { Success = true });
        }

        [HttpPut, Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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

        [HttpGet, Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> ConsultarCargo(int id)
        {
            var cargo = await _service.GetCargo(id);
            return Ok(cargo);
        }

        [HttpGet, Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("api/[controller]/GetAllCargosByDescricao/{descricao}")]
        public async Task<IActionResult> BuscarCargo(string descricao)
        {
            var cargo = await _service.GetAllCargosByDescricao(descricao);
            return Ok(cargo);
        }

        [HttpDelete, Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> DeletarCargo(int id)
        {
            await _service.DeleteCargo(id);
            return Ok(new { Success = true });
        }
    }
}
