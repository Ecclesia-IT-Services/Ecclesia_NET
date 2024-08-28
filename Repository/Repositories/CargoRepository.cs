using Ecclesia.Domain;
using Ecclesia.Repository.Contracts;
using Microsoft.Extensions.Configuration;
using Dapper;

namespace Ecclesia.Repository.Repositories
{
    public class CargoRepository : BaseRepository, ICargoRepository
    {
        public CargoRepository(IConfiguration configuration) : base(configuration)
        {
        }
        public async Task DeleteCargo(int id)
        {
            #region sql
            var sql = $@"
                delete from cargo where id = @id
            ";
            #endregion

            await _connection.ExecuteAsync(sql, new { Id = id });
        }
        public async Task<List<Cargo>> GetAllCargos(string descricao)
        {
            var like = $"%{descricao}%";
            #region sql
            var sql = $@"
                select * from cargo where descricao like @like
            ";
            #endregion

            var cargos = await _connection.QueryAsync<Cargo>(sql, new {Like = like});
            return (List<Cargo>)cargos;
        }

        public async Task<List<Cargo>> GetAllCargos()
        {
            #region sql
            var sql = $@"
                select * from cargo
            ";
            #endregion

            var cargos = await _connection.QueryAsync<Cargo>(sql);
            return (List<Cargo>)cargos;
        }

        public async Task<Cargo> GetCargo(int id)
        {
            #region sql
            var sql = $@"
                select * from cargo where id = @id
            ";
            #endregion

            var cargo = await _connection.QueryAsync<Cargo>(sql, new { Id = id });
            return (Cargo)cargo.FirstOrDefault();
        }
        public async Task InsertCargo(Cargo cargo)
        {
            #region sql
            var sql = $@"
                insert into cargo 
                (   
                    descricao, 
                    usuariocriacao                  
                ) values 
                (
                    @descricao, 
                    @usuariocriacao               
                );
            ";
            #endregion

            await _connection.ExecuteAsync(sql, cargo);
        }
        public async Task UpdateCargo(Cargo cargo)
        {
            #region sql
            var sql = $@"
               update cargo 
               set descricao = @descricao,
                   status = @status,
                   usuarioultimaalteracao = @usuarioultimaalteracao,
                   dataultimaalteracao = now()
               where id = @id
            ";
            #endregion

            await _connection.ExecuteAsync(sql, cargo);
        }
    }
}
