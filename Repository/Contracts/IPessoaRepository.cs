using Ecclesia.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecclesia.Repository.Contracts
{
    public interface IPessoaRepository
    {
        Task Insert(Pessoa pessoa);
        Task Update(Pessoa pessoa);
        Task<Pessoa> Get(int id);
        Task<List<Pessoa>> GetAll(string nome);
        Task Delete(int id);
    }
}
