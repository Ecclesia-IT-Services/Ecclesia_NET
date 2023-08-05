using Domain;
using Ecclesia.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecclesia.Repository.Contracts
{
    public interface ICargoRepository
    {
        Task InsertCargo(Cargo cargo);
        Task UpdateCargo(Cargo cargo);
        Task<Cargo> GetCargo(int id);
        Task<List<Cargo>> GetAllCargos();
        Task DeleteCargo(int id);
    }
}
