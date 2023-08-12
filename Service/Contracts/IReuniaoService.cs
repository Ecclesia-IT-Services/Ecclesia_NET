using Domain;
using Ecclesia.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecclesia.Service.Contracts
{
    public interface IReuniaoService
    {
        Task Insert(Reuniao reuniao);
        Task Update(Reuniao reuniao);
        Task<Reuniao> Get(int id);
        Task<List<Reuniao>> GetAllByIgreja(DateTime dataInicio, DateTime dataFim, int igreja);
        Task<List<Reuniao>> GetAllByCelula(DateTime dataInicio, DateTime dataFim, int celula);
        Task Delete(int id);
    }
}
