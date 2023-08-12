using Ecclesia.Api.Dto;
using Ecclesia.Domain;
using Ecclesia.Service.Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecclesia.Api.Controllers
{
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _service;

        public PessoaController(IPessoaService service)
        {
            _service = service;
        }

        [HttpPost, Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("api/[controller]")]
        public async Task<IActionResult> CadastrarPessoa([FromBody] PessoaInsertDto dto)
        {
            await _service.Insert(
                new Pessoa
                {
                    Nome = dto.Nome,
                    DataNascimento = dto.DataNascimento,
                    DataIngresso = dto.DataIngresso,
                    Igreja = dto.Igreja,
                    Celula = dto.Celula,
                    Cargo = dto.Cargo,
                    DataBatismo = dto.DataBatismo,
                    UsuarioCriacao = dto.Usuario
                });

            return Ok(new { Success = true });
        }

        [HttpPut, Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("api/[controller]")]
        public async Task<IActionResult> AtualizarPessoa([FromBody] PessoaUpdateDto dto)
        {
            await _service.Update(
                new Pessoa
                {
                    Id = dto.Id,
                    Nome = dto.Nome,
                    DataNascimento = dto.DataNascimento,
                    DataIngresso = dto.DataIngresso,
                    Igreja = dto.Igreja,
                    Celula = dto.Celula,
                    Cargo = dto.Cargo,
                    DataBatismo = dto.DataBatismo,
                    UsuarioUltimaAlteracao = dto.Usuario,
                    Status = dto.Status,
                });
            return Ok(new { Success = true });
        }

        [HttpGet, Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> ConsultarPessoa(int id)
        {
            return Ok(await _service.Get(id));
        }

        [HttpGet, Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("api/[controller]/GetAll/{nome}")]
        public async Task<IActionResult> BuscarPessoas(string nome)
        {
            return Ok(await _service.GetAll(nome));
        }

        [HttpDelete, Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("api/[controller]/{id}")]
        public async Task<IActionResult> DeletarPessoa(int id)
        {
            await _service.Delete(id);
            return Ok(new { Success = true });
        }
    }
}
