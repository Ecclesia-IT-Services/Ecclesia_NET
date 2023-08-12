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
    public class OrganizacaoRepository : BaseRepository, IOrganizacaoRepository
    {
        public OrganizacaoRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task Delete(int id)
        {
            #region sql
            var sql = $@"
                delete from organizacao where id = @id
            ";
            #endregion

            await _connection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<Organizacao> Get(int id)
        {
            #region sql
            var sql = $@"
                select * from organizacao where id = @id
            ";
            #endregion

            var reg = await _connection.QueryAsync<Organizacao>(sql, new { Id = id });
            return (Organizacao)reg.FirstOrDefault();
        }

        public async Task<List<Organizacao>> GetAll(string nome)
        {
            var like = $"%{nome}%";
            #region sql
            var sql = $@"
                select * from organizacao where nome like @like
            ";
            #endregion

            var regs = await _connection.QueryAsync<Organizacao>(sql, new { Like = like });
            return (List<Organizacao>)regs;
        }

        public async Task Insert(Organizacao reg)
        {
            #region sql
            var sql = $@"
                insert into organizacao 
                (   
                    nome,
                    cnpj,
                    datacriacao,
                    usuariocriacao                  
                ) values 
                (
                    @nome,
                    @cnpj,                
                    now(),
                    @usuariocriacao        
                );
            ";
            #endregion

            await _connection.ExecuteAsync(sql, reg);
        }

        public async Task Update(Organizacao reg)
        {
            #region sql
            var sql = $@"
               update organizacao 
               set nome = @nome,
                   cnpj = @cnpj,
                   usuarioultimaalteracao = @usuarioultimaalteracao,
                   dataultimaalteracao = now()
               where id = @id
            ";
            #endregion

            await _connection.ExecuteAsync(sql, reg);
        }
    }
}
