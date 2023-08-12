using Dapper;
using Ecclesia.Domain;
using Ecclesia.Repository.Contracts;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecclesia.Repository.Repositories
{
    public class PessoaRepository : BaseRepository, IPessoaRepository
    {
        public PessoaRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task Delete(int id)
        {
            #region sql
            var sql = $@"
                delete from pessoa where id = @id
            ";
            #endregion

            await _connection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<Pessoa> Get(int id)
        {
            #region sql
            var sql = $@"
                select * from pessoa where id = @id
            ";
            #endregion

            var reg = await _connection.QueryAsync<Pessoa>(sql, new { Id = id });
            return (Pessoa)reg.FirstOrDefault();
        }

        public async Task<List<Pessoa>> GetAll(string nome)
        {
            #region sql
            var like = $"%{nome}%";
            var sql = $@"
                select * from pessoa where nome like @like
            ";
            #endregion

            var regs = await _connection.QueryAsync<Pessoa>(sql, new {Like = like});
            return (List<Pessoa>)regs;
        }

        public async Task Insert(Pessoa pessoa)
        {
            #region sql
            var sql = $@"
                insert into pessoa 
                (   
                    nome, 
                    datanascimento,
                    dataingresso,
                    igreja,
                    celula,
                    cargo,
                    databatismo,
                    datacriacao,
                    usuariocriacao                  
                ) values 
                (
                    @nome, 
                    @datanascimento,
                    @dataingresso,
                    @igreja,
                    @celula,
                    @cargo,
                    @databatismo,
                    now(),
                    @usuariocriacao        
                );
            ";
            #endregion

            await _connection.ExecuteAsync(sql, pessoa);
        }

        public async Task Update(Pessoa pessoa)
        {
            #region sql
            var sql = $@"
               update pessoa 
               set nome = @nome,
                   datanascimento = @datanascimento,
                   dataingresso = @dataingresso,
                   igreja = @igreja,
                   celula = @celula,
                   cargo = @cargo,
                   databatismo = @databatismo,
                   status = @status,
                   usuarioultimaalteracao = @usuarioultimaalteracao,
                   dataultimaalteracao = now()
               where id = @id
            ";
            #endregion

            await _connection.ExecuteAsync(sql, pessoa);
        }
    }
}
