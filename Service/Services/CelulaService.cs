using Ecclesia.Domain;
using Ecclesia.Repository.Contracts;
using Ecclesia.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ecclesia.Service.Services
{
    public class CelulaService : ICelulaService
    {
        private readonly ICelulaRepository _repository;

        public CelulaService(ICelulaRepository repository)
        {
            _repository = repository;
        }

        public async Task Delete(int id)
        {
            if (await _repository.Get(id) == null)
                throw new BusinessHttpResponseException(Messages.Message(HttpStatusCode.NotFound));
            await _repository.Delete(id);
        }

        public async Task<Celula> Get(int id) => await _repository.Get(id);

        public async Task<List<Celula>> GetAll(string nome) => await _repository.GetAll(nome);

        public async Task<List<Celula>> GetAll(int igreja) => await _repository.GetAll(igreja);

        public async Task Insert(Celula reg) => await _repository.Insert(reg);

        public async Task Update(Celula reg)
        {
            if (await _repository.Get(reg.Id) == null)
                throw new BusinessHttpResponseException(Messages.Message(HttpStatusCode.NotFound));
            await _repository.Update(reg);
        }
    }
}
