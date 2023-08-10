using Domain;

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
