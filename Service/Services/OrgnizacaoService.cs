using Ecclesia.Domain;
using Ecclesia.Repository.Contracts;
using Ecclesia.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ecclesia.Repository.Repositories
{
    public class OrganizacaoService : IOrganizacaoService
    {
        private readonly IOrganizacaoRepository _repository;

        public OrganizacaoService(IOrganizacaoRepository repository)
        {
            _repository = repository;
        }

        public async Task Delete(int id)
        {
            if (await _repository.Get(id) == null)
                throw new BusinessHttpResponseException(Messages.Message(HttpStatusCode.NotFound));
            await _repository.Delete(id);
        }

        public async Task<Organizacao> Get(int id) => await _repository.Get(id);

        public async Task<List<Organizacao>> GetAll(string nome) => await _repository.GetAll(nome);

        public async Task Insert(Organizacao reg) => await _repository.Insert(reg);

        public async Task Update(Organizacao reg)
        {
            if (await _repository.Get(reg.Id) == null)
                throw new BusinessHttpResponseException(Messages.Message(HttpStatusCode.NotFound));
            await _repository.Update(reg);
        }
    }
}
