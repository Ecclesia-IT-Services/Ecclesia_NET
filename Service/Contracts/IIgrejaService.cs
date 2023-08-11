using Ecclesia.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecclesia.Service.Contracts
{
    public interface IIgrejaService
    {
        Task InsertIgreja(Igreja igreja);
        Task UpdateIgreja(Igreja Igreja);
        Task<Igreja> GetIgreja(int id);
        Task<List<Igreja>> GetAllIgrejasByNome(string nome);
        Task DeleteIgreja(int id);
    }
}
