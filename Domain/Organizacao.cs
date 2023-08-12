using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecclesia.Domain
{
    public class Organizacao : ModelBase
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
    }
}
