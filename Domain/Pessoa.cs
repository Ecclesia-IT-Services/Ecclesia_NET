using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecclesia.Domain
{
    public class Pessoa : ModelBase
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataIngresso { get; set; }
        public int Igreja { get; set; }
        public int Celula { get; set; }
        public int Cargo { get; set; }
        public DateTime DataBatismo { get; set; }
    }
}
