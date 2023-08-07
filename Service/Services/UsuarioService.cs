using Domain;
using Repository.Contracts;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var usuarios = await _repository.GetAllUsuarios();
            var filter = usuarios.Where(p => p.Nome.Contains(nome)).Where(p => p.Status == "A");
            return filter.ToList();
        }

        public async Task<Usuario> GetUsuario(int id)
        {
            var usuario = await _repository.GetUsuario(id);
            return usuario;
        }

        public async Task InsertUsuario(Usuario usuario)
        {
            await _repository.InsertUsuario(usuario);
        }

        public async Task UpdateUsuario(Usuario usuario)
        {
            await _repository.UpdateUsuario(usuario);
        }
    }
}
