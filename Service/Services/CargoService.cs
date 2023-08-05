using Domain;
using Ecclesia.Domain;
using Ecclesia.Repository.Contracts;
using Ecclesia.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecclesia.Service.Services
{
    public class CargoService: ICargoService
    {
        private readonly ICargoRepository _repository;

        public CargoService(ICargoRepository cargoRepository)
        {
            _repository = cargoRepository;
        }

        public async Task DeleteCargo(int id)
        {
            await _repository.DeleteCargo(id);
        }

        public async Task<List<Cargo>> GetAllCargosByDescricao(string descricao)
        {
            var cargos = await _repository.GetAllCargos();
            var filter = cargos.Where(p => p.Descricao.Contains(descricao)).Where(p => p.Status == "A");
            return (List<Cargo>)cargos;
        }

        public async Task<Cargo> GetCargo(int id)
        {
            var cargo = await _repository.GetCargo(id);
            return cargo;
        }

        public async Task InsertCargo(Cargo cargo)
        {
            await _repository.InsertCargo(cargo);
        }

        public async Task UpdateCargo(Cargo cargo)
        {
            await _repository.UpdateCargo(cargo);
        }
    }
}
