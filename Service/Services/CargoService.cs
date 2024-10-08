﻿using Ecclesia.Domain;
using Ecclesia.Repository.Contracts;
using Ecclesia.Service.Contracts;
using System.Net;

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
            var reg = _repository.GetCargo(id);
            if (reg == null) throw new BusinessHttpResponseException(Messages.Message(HttpStatusCode.NotFound));
            await _repository.DeleteCargo(id);
        }

        public async Task<List<Cargo>> GetAllCargosByDescricao(string descricao)
        {
            var cargos = await _repository.GetAllCargos(descricao);     
            return cargos.ToList();
        }

        public async Task<List<Cargo>> GetAllCargos()
        {
            var cargos = await _repository.GetAllCargos();
            return cargos.ToList();
        }

        public async Task<Cargo> GetCargo(int id)
        {
            var cargo = await _repository.GetCargo(id);
            if (cargo ==  null) throw new BusinessHttpResponseException(HttpStatusCode.NotFound);
            return cargo;
        }

        public async Task InsertCargo(Cargo cargo)
        {
            await _repository.InsertCargo(cargo);
        }

        public async Task UpdateCargo(Cargo cargo)
        {
            var reg = _repository.GetCargo(cargo.Id);
            if (reg == null) throw new BusinessHttpResponseException(Messages.Message(HttpStatusCode.NotFound));
            await _repository.UpdateCargo(cargo);
        }
    }
}
