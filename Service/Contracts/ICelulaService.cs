using Ecclesia.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecclesia.Service.Contracts
{
    public interface ICelulaService
    {
        Task Insert(Celula reg);
        Task Update(Celula reg);
        Task<Celula> Get(int id);
        Task<List<Celula>> GetAll(string nome);
        Task<List<Celula>> GetAll(int igreja);
        Task Delete(int id);
    }
}
