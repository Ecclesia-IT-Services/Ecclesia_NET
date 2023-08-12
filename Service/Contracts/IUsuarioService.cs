using Domain;

namespace Service.Contracts
{
    public interface IUsuarioService
    {
        Task InsertUsuario(Usuario usuario);
        Task UpdateUsuario(Usuario usuario);
        Task<Usuario> GetUsuario(int id);
        Task<List<Usuario>> GetAllUsuariosByName(string nome);
        Task DeleteUsuario(int id);
    }
}
