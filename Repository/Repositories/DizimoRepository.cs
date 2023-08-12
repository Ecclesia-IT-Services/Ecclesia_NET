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
    public class DizimoRepository : BaseRepository, IDizimoRepository
    {
        public DizimoRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task Delete(int id)
        {
            #region sql
            var sql = $@"
                delete from dizimo where id = @id
            ";
            #endregion

            await _connection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<Dizimo> Get(int id)
        {
            #region sql
            var sql = $@"
                select * from dizimo where id = @id
            ";
            #endregion

            var reg = await _connection.QueryAsync<Dizimo>(sql, new { Id = id });
            return (Dizimo)reg.FirstOrDefault();
        }

        public async Task<List<Dizimo>> GetAll(int reuniao)
        {
            #region sql
            var sql = $@"
                select * from dizimo where reuniao = @reuniao
            ";
            #endregion

            var regs = await _connection.QueryAsync<Dizimo>(sql, new { Reuniao = reuniao });
            return (List<Dizimo>)regs;
        }

        public async Task<List<Dizimo>> GetAll(int membro, DateTime dataInicio, DateTime dataFim)
        {
            #region sql
            var sql = $@"
                select * 
                from dizimo a
                join reuniao b on a.reuniao = b.id
                where a.membro = @membro 
                and b.data between @dataInicio and @dataFim
            ";
            #endregion

            var regs = await _connection.QueryAsync<Dizimo>(sql, new { Membro = membro, DataInicio = dataInicio, DataFim = dataFim });
            return (List<Dizimo>)regs;
        }

        public async Task Insert(Dizimo reg)
        {
            #region sql
            var sql = $@"
                insert into dizimo 
                (   
                    reuniao,
                    membro,
                    valor,
                    datacriacao,
                    usuariocriacao                  
                ) values 
                (
                    @reuniao,
                    @membro,
                    @valor,                    
                    now(),
                    @usuariocriacao        
                );
            ";
            #endregion

            await _connection.ExecuteAsync(sql, reg);
        }

        public async Task Update(Dizimo reg)
        {
            #region sql
            var sql = $@"
               update dizimo 
               set valor = @valor,
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
