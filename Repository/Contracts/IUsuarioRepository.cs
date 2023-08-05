using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contracts
{
    public interface IUsuarioRepository
    {
        Task InsertUsuario(Usuario usuario);
        Task UpdateUsuario(Usuario usuario);
        Task<Usuario> GetUsuario(int id);
        Task<List<Usuario>> GetAllUsuarios();
        Task DeleteUsuario(int id);
    }
}
