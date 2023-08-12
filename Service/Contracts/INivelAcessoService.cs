using Ecclesia.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecclesia.Service.Contracts
{
    public interface INivelAcessoService
    {
        Task Insert(NivelAcesso reg);
        Task Update(NivelAcesso reg);
        Task<NivelAcesso> Get(int id);
        Task<List<NivelAcesso>> GetAll(string descricao);
        Task Delete(int id);
    }
}
