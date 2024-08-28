using Ecclesia.Domain;

namespace Ecclesia.Service.Contracts
{
    public interface ICargoService
    {
        Task InsertCargo(Cargo cargo);
        Task UpdateCargo(Cargo cargo);
        Task<Cargo> GetCargo(int id);
        Task<List<Cargo>> GetAllCargosByDescricao(string descricao);
        Task<List<Cargo>> GetAllCargos();
        Task DeleteCargo(int id);
    }
}
