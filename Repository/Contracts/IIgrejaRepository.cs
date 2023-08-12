using Ecclesia.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecclesia.Repository.Contracts
{
    public interface IIgrejaRepository
    {
        Task InsertIgreja(Igreja igreja);
        Task UpdateIgreja(Igreja igreja);
        Task<Igreja> GetIgreja(int id);
        Task<List<Igreja>> GetAllIgrejas(string nome);
        Task DeleteIgreja(int id);
    }
}
