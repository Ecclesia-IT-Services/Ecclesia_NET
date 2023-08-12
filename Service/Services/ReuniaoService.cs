using Ecclesia.Domain;
using Ecclesia.Repository.Contracts;
using Ecclesia.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Ecclesia.Service.Services
{
    public class ReuniaoService : IReuniaoService
    {
        private readonly IReuniaoRepository _repository;

        public ReuniaoService(IReuniaoRepository repository)
        {
            _repository = repository;
        }

        public async Task Delete(int id)
        {
            if (await _repository.Get(id) == null)
                throw new BusinessHttpResponseException(Messages.Message(HttpStatusCode.NotFound));
            await _repository.Delete(id);
        }

        public async Task<Reuniao> Get(int id)
        {
            return await _repository.Get(id);
        }

        public async Task<List<Reuniao>> GetAllByCelula(DateTime dataInicio, DateTime dataFim, int celula)
        {
            return await _repository.GetAllByCelula(dataInicio, dataFim, celula);
        }

        public async Task<List<Reuniao>> GetAllByIgreja(DateTime dataInicio, DateTime dataFim, int igreja)
        {
            return await _repository.GetAllByIgreja(dataInicio, dataFim, igreja);
        }

        public async Task Insert(Reuniao reuniao)
        {
            await _repository.Insert(reuniao);
        }

        public async Task Update(Reuniao reuniao)
        {
            if (await _repository.Get(reuniao.Id) == null) 
                throw new BusinessHttpResponseException(Messages.Message(HttpStatusCode.NotFound));
            await _repository.Update(reuniao);
        }
    }
}
