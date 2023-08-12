using Domain;

namespace Ecclesia.Service.Contracts
{
    public interface ISegurancaService
    {
        Task<bool> ValidarUsuario(Usuario usuario);
        Task<string> GerarTokenJwt();
    }
}
