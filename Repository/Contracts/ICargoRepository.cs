using Ecclesia.Domain;

namespace Ecclesia.Repository.Contracts
{
    public interface ICargoRepository
    {
        Task InsertCargo(Cargo cargo);
        Task UpdateCargo(Cargo cargo);
        Task<Cargo> GetCargo(int id);
        Task<List<Cargo>> GetAllCargos(string descricao);
        Task DeleteCargo(int id);
    }
}
