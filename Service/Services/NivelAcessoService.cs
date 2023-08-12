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
    public class NivelAcessoService : INivelAcessoService
    {
        private readonly INivelAcessoRepository _repository;

        public NivelAcessoService(INivelAcessoRepository repository)
        {
            _repository = repository;
        }

        public async Task Delete(int id)
        {
            if (await _repository.Get(id) == null)
                throw new BusinessHttpResponseException(Messages.Message(HttpStatusCode.NotFound));
            await _repository.Delete(id);
        }

        public async Task<NivelAcesso> Get(int id) => await _repository.Get(id);

        public async Task<List<NivelAcesso>> GetAll(string descricao) => await _repository.GetAll(descricao);

        public async Task Insert(NivelAcesso reg) => await _repository.Insert(reg);

        public async Task Update(NivelAcesso reg)
        {
            if (await _repository.Get(reg.Id) == null)
                throw new BusinessHttpResponseException(Messages.Message(HttpStatusCode.NotFound));
            await _repository.Update(reg);
        }
    }
}
