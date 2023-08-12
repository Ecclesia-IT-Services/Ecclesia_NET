using Dapper;
using Ecclesia.Domain;
using Ecclesia.Repository.Contracts;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecclesia.Repository.Repositories
{
    public class NivelAcessoRepository : BaseRepository, INivelAcessoRepository
    {
        public NivelAcessoRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task Delete(int id)
        {
            #region sql
            var sql = $@"
                delete from nivelacesso where id = @id
            ";
            #endregion

            await _connection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<NivelAcesso> Get(int id)
        {
            #region sql
            var sql = $@"
                select * from nivelacesso where id = @id
            ";
            #endregion

            var reg = await _connection.QueryAsync<NivelAcesso>(sql, new { Id = id });
            return (NivelAcesso)reg.FirstOrDefault();
        }

        public async Task<List<NivelAcesso>> GetAll(string descricao)
        {
            #region sql
            var like = $"%{descricao}%";
            var sql = $@"
                select * from nivelacesso where descricao like @like
            ";
            #endregion

            var regs = await _connection.QueryAsync<NivelAcesso>(sql, new { Like = like });
            return (List<NivelAcesso>)regs;
        }

        public async Task Insert(NivelAcesso reg)
        {
            #region sql
            var sql = $@"
                insert into nivelacesso 
                (   
                    descricao,
                    datacriacao,
                    usuariocriacao                  
                ) values 
                (
                    @descricao,                    
                    now(),
                    @usuariocriacao        
                );
            ";
            #endregion

            await _connection.ExecuteAsync(sql, reg);
        }

        public async Task Update(NivelAcesso reg)
        {
            #region sql
            var sql = $@"
               update nivelacesso 
               set descricao = @descricao,
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
