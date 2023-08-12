using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecclesia.Domain
{
    public class Dizimo : ModelBase
    {
        public int Id { get; set; }
        public int Reuniao { get; set; }
        public int Membro { get; set; }
        public decimal Valor { get; set; } 
    }
}
