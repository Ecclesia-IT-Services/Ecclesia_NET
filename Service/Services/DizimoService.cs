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
    public class DizimoService : IDizimoService
    {
        private readonly IDizimoRepository _repository;

        public DizimoService(IDizimoRepository repository)
        {
            _repository = repository;
        }

        public async Task Delete(int id)
        {
            if (await _repository.Get(id) == null)
                throw new BusinessHttpResponseException(Messages.Message(HttpStatusCode.NotFound));
            await _repository.Delete(id);
        }

        public async Task<Dizimo> Get(int id) => await _repository.Get(id);

        public async Task<List<Dizimo>> GetAll(int reuniao) => await _repository.GetAll(reuniao);

        public async Task<List<Dizimo>> GetAll(int membro, DateTime dataInicio, DateTime dataFim) => await _repository.GetAll(membro, dataInicio, dataFim);

        public async Task Insert(Dizimo reg) => await _repository.Insert(reg);

        public async Task Update(Dizimo reg)
        {
            if (await _repository.Get(reg.Id) == null)
                throw new BusinessHttpResponseException(Messages.Message(HttpStatusCode.NotFound));
            await _repository.Update(reg);
        }
    }
}
