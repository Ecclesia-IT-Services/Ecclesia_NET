using Ecclesia.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecclesia.Repository.Contracts
{
    public interface IDizimoRepository
    {
        Task Insert(Dizimo reg);
        Task Update(Dizimo reg);
        Task<Dizimo> Get(int id);
        Task<List<Dizimo>> GetAll(int reuniao);
        Task<List<Dizimo>> GetAll(int membro, DateTime dataInicio, DateTime dataFim);
        Task Delete(int id);
    }
}
