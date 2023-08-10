using Domain;
using Ecclesia.Domain;
using Ecclesia.Service.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Repository.Contracts;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Text;

namespace Ecclesia.Service.Services
{
    public class SegurancaService : ISegurancaService
    {
        private readonly IConfiguration _configuration;
        private readonly IUsuarioRepository _repository;
        public SegurancaService(IConfiguration configuration, IUsuarioRepository repository)
        {
            _repository = repository;
            _configuration = configuration;
        }
        public async Task<string> GerarTokenJwt()
        {
            var issuer = _configuration.GetSection("Jwt").GetSection("Issuer").Value;
            var audience = _configuration.GetSection("Jwt").GetSection("Audience").Value;
            var expiry = DateTime.Now.AddMinutes(60);
            var securityKey = new SymmetricSecurityKey
                              (Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt").GetSection("Key").Value));
            var credentials = new SigningCredentials
                              (securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(issuer: issuer,
                                             audience: audience,
                                             expires: DateTime.Now.AddMinutes(120),
                                             signingCredentials: credentials);
            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }

        public async Task<bool> ValidarUsuario(Usuario usuario)
        {
            var list = await _repository
                .GetAllUsuarios();
            var filter = list
                .Where(p => p.Login == usuario.Login);
            if (!filter.Any())
            {
                throw new BusinessHttpResponseException(Messages.Message(HttpStatusCode.NotFound));
            }               
            return filter.First().Senha == usuario.Senha;                
        }
    }
}
