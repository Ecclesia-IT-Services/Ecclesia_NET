using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Ecclesia.Repository.Repositories
{
    public class BaseRepository
    {
        internal NpgsqlConnection _connection;
        internal IConfiguration _configuration;
        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = new NpgsqlConnection(_configuration.GetConnectionString(_configuration.GetSection("Ambiente").Value));         
            _connection.Open();
        }
    }
}
