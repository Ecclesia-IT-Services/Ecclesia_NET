using Domain;
using Repository.Contracts;
using Npgsql;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Reflection.Metadata.Ecma335;
using System.Data;
using NpgsqlTypes;
using System.Xml.Linq;
using Domain.Enum;
using System.Data.Common;

namespace Repository.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private NpgsqlConnection _connection;
        private IConfiguration _configuration;

        public UsuarioRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = new NpgsqlConnection(_configuration.GetConnectionString("drona"));
            _connection.Open();
            
        }

        public async Task DeleteUsuario(int id)
        {
            #region sql
            var sql = $@"
                delete from usuario where id = @id
            ";
            #endregion

            await _connection.ExecuteAsync(sql, new { Id = id});
        }

        public async Task<Usuario> GetUsuario(int id)
        {
            #region sql
            var sql = $@"
                select * from usuario where id = @id
            ";
            #endregion

            var usuario = await _connection.QueryAsync<Usuario>(sql,new {Id = id});
            return (Usuario)usuario.FirstOrDefault();
        }

       

        public async Task InsertUsuario(Usuario usuario)
        {
            #region sql
            var sql = $@"
                insert into usuario 
                (   
                    login, 
                    nome, 
                    senha, 
                    nivelacesso, 
                    usuariocriacao
                ) values 
                (
                    @login, 
                    @nome, 
                    @senha, 
                    @nivelacesso, 
                    @usuariocriacao
                );
            ";
            #endregion

            await _connection.ExecuteAsync(sql,usuario);           
        }

        public async Task UpdateUsuario(Usuario usuario)
        {
            #region sql
            var sql = $@"
               update usuario 
               set senha = @senha,
                   nivelacesso = @nivelacesso,
                   status = @status
               where id = @id
            ";
            #endregion

            await _connection.ExecuteAsync(sql, usuario);           
        }
    }
}
