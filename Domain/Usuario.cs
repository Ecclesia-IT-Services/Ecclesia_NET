using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Usuario
    {
        public int Id { get; private set; }
        public string Login { get; private set; }
        public string Nome { get; private set; }
        public string Senha { get; private set; }
        public int NivelAcesso { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public int UsuarioCriacao { get; private set; }
        public DateTime DataUltimaAlteracao { get; private set; }
        public int UsuarioUltimaAlteracao { get; private set; }
        public string Status { get; private set; }

        public Usuario(int id, string login, string nome, string senha, 
                        int nivelAcesso, DateTime dataCriacao, int usuarioCriacao, 
                        DateTime dataUltimaAlteracao, int usuarioUltimaAlteracao, string status)
        {
            Id = id;
            Login = login;
            Nome = nome;
            Senha = senha;
            NivelAcesso = nivelAcesso;
            DataCriacao = dataCriacao;
            UsuarioCriacao = usuarioCriacao;
            DataUltimaAlteracao = dataUltimaAlteracao;
            UsuarioUltimaAlteracao = usuarioUltimaAlteracao;
            Status = status;
        }
    }
}
