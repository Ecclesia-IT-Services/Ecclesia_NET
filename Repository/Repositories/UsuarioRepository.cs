using Domain;
using Repository.Contracts;
using Microsoft.Extensions.Configuration;
using Dapper;
using Ecclesia.Repository.Repositories;

namespace Repository.Repositories
{
    public class UsuarioRepository : BaseRepository,IUsuarioRepository
    {
        public UsuarioRepository(IConfiguration configuration) : base(configuration)
        {
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

        public async Task<List<Usuario>> GetAllUsuarios()
        {
            #region sql
            var sql = $@"
                select * from usuario
            ";
            #endregion

            var usuarios = await _connection.QueryAsync<Usuario>(sql);
            return (List<Usuario>)usuarios;
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
               set nome = @nome,
                   senha = @senha,
                   nivelacesso = @nivelacesso,
                   status = @status,
                   usuarioultimaalteracao = @usuarioultimaalteracao,
                   dataultimaalteracao = now()
               where id = @id
            ";
            #endregion

            await _connection.ExecuteAsync(sql, usuario);           
        }
    }
}
