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
        public int Id { get; set; }
        public string Login { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public int NivelAcesso { get; set; }
        public DateTime DataCriacao { get; set; }
        public int UsuarioCriacao { get; set; }
        public DateTime DataUltimaAlteracao { get; set; }
        public int UsuarioUltimaAlteracao { get; set; }
        public string Status { get; set; }       
    }
}
