using Domain;
using Ecclesia.Domain;
using Repository.Contracts;
using Service.Contracts;
using System.Net;

namespace Service.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
           _repository = repository;
        }

        public async Task DeleteUsuario(int id)
        {
            await _repository.DeleteUsuario(id);
        }

        public async Task<List<Usuario>> GetAllUsuariosByName(string nome)
        {
            var usuarios = await _repository.GetAllUsuarios(nome);            
            return usuarios.ToList();
        }

        public async Task<Usuario> GetUsuario(int id)
        {
            var usuario = await _repository.GetUsuario(id);
            return usuario;
        }
        
        public async Task InsertUsuario(Usuario usuario)
        {
            var registro = _repository.GetUsuario(usuario.Login);

            if (registro != null) //login já existe 
                throw new BusinessHttpResponseException(HttpStatusCode.BadRequest);

            await _repository.InsertUsuario(usuario);
        }

        public async Task UpdateUsuario(Usuario usuario)
        {
            await _repository.UpdateUsuario(usuario);
        }
    }
}
