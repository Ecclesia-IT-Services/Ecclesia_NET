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
    public class ReuniaoRepository : BaseRepository, IReuniaoRepository
    {
        public ReuniaoRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task Delete(int id)
        {
            #region sql
            var sql = $@"
                delete from reuniao where id = @id
            ";
            #endregion

            await _connection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<Reuniao> Get(int id)
        {
            #region sql
            var sql = $@"
                select * from reuniao where id = @id
            ";
            #endregion

            var reg = await _connection.QueryAsync<Reuniao>(sql, new { Id = id });
            return (Reuniao)reg.FirstOrDefault();
        }

        public async Task<List<Reuniao>> GetAllByCelula(DateTime dataInicio, DateTime dataFim, int celula)
        {
            #region sql
            var sql = $@"
                select * 
                from reuniao
                where data between @datainicio and @datafim
                and celula = @celula
            ";
            #endregion

            var regs = await _connection.QueryAsync<Reuniao>(sql, new { DataInicio = dataInicio, DataFim = dataFim, Celula = celula });
            return (List<Reuniao>)regs;
        }

        public async Task<List<Reuniao>> GetAllByIgreja(DateTime dataInicio, DateTime dataFim, int igreja)
        {
            #region sql
            var sql = $@"
                select * 
                from reuniao
                where data between @datainicio and @datafim
                and igreja = @igreja
            ";
            #endregion

            var regs = await _connection.QueryAsync<Reuniao>(sql, new { DataInicio = dataInicio, DataFim = dataFim, Igreja = igreja });
            return (List<Reuniao>)regs;
        }

        public async Task Insert(Reuniao reuniao)
        {
            #region sql
            var sql = $@"
                insert into reuniao 
                (   
                    data, 
                    igreja, 
                    celula, 
                    pregador, 
                    quantidadeparticipantes, 
                    quantidadevisitantes, 
                    quantidadecriancas, 
                    valorofertas, 
                    valorofertasespeciais, 
                    valorprimicias, 
                    datacriacao, 
                    usuariocriacao
	                
                ) values 
                (
                    @data, 
                    @igreja, 
                    @celula, 
                    @pregador, 
                    @quantidadeparticipantes, 
                    @quantidadevisitantes, 
                    @quantidadecriancas, 
                    @valorofertas, 
                    @valorofertasespeciais, 
                    @valorprimicias, 
                    now(), 
                    @usuariocriacao            
                );
            ";
            #endregion

            await _connection.ExecuteAsync(sql, reuniao);
        }

        public async Task Update(Reuniao reuniao)
        {
            #region sql
            var sql = $@"
               update reuniao 
               set pregador = @pregador, 
                   quantidadeparticipantes = @quantidadeparticipantes, 
                   quantidadevisitantes = @quantidadevisitantes, 
                   quantidadecriancas = @quantidadecriancas, 
                   valorofertas = @valorofertas, 
                   valorofertasespeciais = @valorofertasespeciais, 
                   valorprimicias = @valorprimicias, 
                   dataultimaalteracao = now(),
                   usuarioultimaalteracao = @usuarioultimaalteracao,
                   status = @status
               where id = @id
            ";
            #endregion

            await _connection.ExecuteAsync(sql, reuniao);
        }
    }
}
