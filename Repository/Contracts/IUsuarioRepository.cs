using Domain;

namespace Repository.Contracts
{
    public interface IUsuarioRepository
    {
        Task InsertUsuario(Usuario usuario);
        Task UpdateUsuario(Usuario usuario);
        Task<Usuario> GetUsuario(int id);
        Task<Usuario> GetUsuario(string login);
        Task<List<Usuario>> GetAllUsuarios(string nome);   
        Task DeleteUsuario(int id);
    }
}
