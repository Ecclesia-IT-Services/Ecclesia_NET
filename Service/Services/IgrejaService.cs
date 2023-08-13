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
    public class IgrejaService:IIgrejaService
    {
        private readonly IIgrejaRepository _repository;

        public IgrejaService(IIgrejaRepository igrejaRepository)
        {
            _repository = igrejaRepository;
        }

        public async Task DeleteIgreja(int id)
        {
            var reg = await _repository.GetIgreja(id);
            if (reg == null) throw new BusinessHttpResponseException(Messages.Message(HttpStatusCode.NotFound));
            await _repository.DeleteIgreja(id);
        }

        public async Task<List<Igreja>> GetAllIgrejasByNome(string nome)
        {
            var igrejas = await _repository.GetAllIgrejas(nome);
            return igrejas.ToList();
        }

        public async Task<Igreja> GetIgreja(int id)
        {
            var igreja = await _repository.GetIgreja(id);
            if (igreja == null) throw new BusinessHttpResponseException(HttpStatusCode.NotFound);
            return igreja;
        }

        public async Task InsertIgreja(Igreja igreja)
        {
            await _repository.InsertIgreja(igreja);
        }

        public async Task UpdateIgreja(Igreja igreja)
        {
            var reg = await _repository.GetIgreja(igreja.Id);
            if (reg == null) throw new BusinessHttpResponseException(Messages.Message(HttpStatusCode.NotFound));
            await _repository.UpdateIgreja(igreja);
        }
    }
}
