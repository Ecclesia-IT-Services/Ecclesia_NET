﻿using Ecclesia.Domain;
using Ecclesia.Repository.Contracts;
using Ecclesia.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecclesia.Service.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _repository;

        public PessoaService(IPessoaRepository repository)
        {
            _repository = repository;
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<Pessoa> Get(int id)
        {
            return await _repository.Get(id);
        }

        public async Task<List<Pessoa>> GetAll(string nome)
        {
            return await _repository.GetAll(nome); 
        }

        public async Task Insert(Pessoa pessoa)
        {
            await _repository.Insert(pessoa);
        }

        public async Task Update(Pessoa pessoa)
        {
            await _repository.Update(pessoa);
        }
    }
}
