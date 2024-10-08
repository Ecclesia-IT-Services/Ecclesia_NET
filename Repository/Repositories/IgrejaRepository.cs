﻿using Dapper;
using Ecclesia.Domain;
using Ecclesia.Repository.Contracts;
using Ecclesia.Repository.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecclesia.Repository
{
    public class IgrejaRepository : BaseRepository, IIgrejaRepository
    {
        public IgrejaRepository(IConfiguration configuration) : base(configuration)
        {
        }
        public async Task DeleteIgreja(int id)
        {
            #region sql
            var sql = $@"
                delete from igreja where id = @id
            ";
            #endregion

            await _connection.ExecuteAsync(sql, new { Id = id });
        }

       
        public async Task<List<Igreja>> GetAllIgrejas(string nome)
        {
            var like = $"%{nome}%";
            #region sql
            var sql = $@"
                select * from igreja where nome like @like
            ";
            #endregion

            var igrejas = await _connection.QueryAsync<Igreja>(sql, new {Like = like});
            
            return (List<Igreja>)igrejas;
        }
        public async Task<Igreja> GetIgreja(int id)
        {
            #region sql
            var sql = $@"
                select * from igreja where id = @id
            ";
            #endregion

            var igreja = await _connection.QueryAsync<Igreja>(sql, new { Id = id });
            return (Igreja)igreja.FirstOrDefault();
        }
        public async Task InsertIgreja(Igreja igreja)
        {
            #region sql
            var sql = $@"
                insert into igreja
                (   
                     nome,
                     logradouro,
                     numero,
                     complemento,
                     bairro,
                     cidade,
                     uf,
                     usuarioCriacao,
                     dataCriacao

                ) values 
                (
                     @nome,
                     @logradouro,
                     @numero,
                     @complemento,
                     @bairro,
                     @cidade,
                     @uf,
                     @usuarioCriacao,
                     now()

                );
            ";
            #endregion

            await _connection.ExecuteAsync(sql, igreja);
        }

       
        public async Task UpdateIgreja(Igreja igreja)
        {
            #region sql
            var sql = $@"
               update igreja 
               set nome = @nome,
                   logradouro = @logradouro,
                   numero = @numero,
                   complemento = @complemento,
                   bairro = @bairro,
                   cidade = @cidade,
                   uf = @uf,
                   status = @status,
                   usuarioultimaalteracao = @usuarioultimaalteracao,
                   dataultimaalteracao = now()
               where id = @id
            ";
            #endregion

            await _connection.ExecuteAsync(sql, igreja);
        }
    }
}
