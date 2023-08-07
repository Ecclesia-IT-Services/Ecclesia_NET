using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecclesia.Service.Contracts
{
    public interface ISegurancaService
    {
        Task<bool> ValidarUsuario(Usuario usuario);
        Task<string> GerarTokenJwt();
    }
}
