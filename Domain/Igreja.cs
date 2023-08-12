using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecclesia.Domain
{
    public class Igreja
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Logradouro { get; set;}
        public string Numero { get; set;}
        public string Complemento { get; set; }        
        public string Bairro { get; set; }
        public string Cidade { get; set;}
        public string Uf { get; set;}
        public DateTime DataCriacao { get; set;}
        public int UsuarioCriacao { get; set;}
        public DateTime DataUltimaAlteracao { get; set;}
        public int UsuarioUltimaAlteracao { get; set;}
        public string Status { get; set;}

    }
}
 


