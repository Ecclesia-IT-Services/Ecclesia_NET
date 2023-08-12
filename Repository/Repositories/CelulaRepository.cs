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
    public class CelulaRepository : BaseRepository, ICelulaRepository
    {
        public CelulaRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task Delete(int id)
        {
            #region sql
            var sql = $@"
                delete from celula where id = @id
            ";
            #endregion

            await _connection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<Celula> Get(int id)
        {
            #region sql
            var sql = $@"
                select * from celula where id = @id
            ";
            #endregion

            var reg = await _connection.QueryAsync<Celula>(sql, new { Id = id });
            return (Celula)reg.FirstOrDefault();
        }

        public async Task<List<Celula>> GetAll(string nome)
        {
            var like = $"%{nome}%";

            #region sql
            var sql = $@"
                select * from celula where nome LIKE @like
            ";
            #endregion

            var regs = await _connection.QueryAsync<Celula>(sql, new { Like = like });

            return (List<Celula>)regs;
        }

        public async Task<List<Celula>> GetAll(int igreja)
        {
            #region sql
            var sql = $@"
                select * from celula where igreja = @igreja
            ";
            #endregion

            var regs = await _connection.QueryAsync<Celula>(sql, new { Igreja = igreja });

            return (List<Celula>)regs;
        }

        public async Task Insert(Celula reg)
        {
            #region sql
            var sql = $@"
                insert into celula
                (   
                     nome,
                     igreja,
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
                     @igreja,
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

            await _connection.ExecuteAsync(sql, reg);
        }

        public async Task Update(Celula reg)
        {
            #region sql
            var sql = $@"
               update celula 
               set nome = @nome,
                   igreja = @igreja,
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

            await _connection.ExecuteAsync(sql, reg);
        }
    }
}