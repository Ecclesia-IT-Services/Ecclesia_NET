using Domain;
using Ecclesia.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecclesia.Service.Contracts
{
    public interface ICargoService
    {
        Task InsertCargo(Cargo cargo);
        Task UpdateCargo(Cargo cargo);
        Task<Cargo> GetCargo(int id);
        Task<List<Cargo>> GetAllCargosByDescricao(string descricao);
        Task DeleteCargo(int id);
    }
}
