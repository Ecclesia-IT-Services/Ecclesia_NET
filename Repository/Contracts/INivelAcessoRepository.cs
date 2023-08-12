using Ecclesia.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecclesia.Repository.Contracts
{
    public interface INivelAcessoRepository
    {
        Task Insert(NivelAcesso reg);
        Task Update(NivelAcesso reg);
        Task<NivelAcesso> Get(int id);
        Task<List<NivelAcesso>> GetAll(string descricao);
        Task Delete(int id);
    }
}
