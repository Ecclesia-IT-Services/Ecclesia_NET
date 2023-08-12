using Ecclesia.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecclesia.Service.Contracts
{
    public interface IOrganizacaoService
    {
        Task Insert(Organizacao reg);
        Task Update(Organizacao reg);
        Task<Organizacao> Get(int id);
        Task<List<Organizacao>> GetAll(string nome);
        Task Delete(int id);
    }
}
