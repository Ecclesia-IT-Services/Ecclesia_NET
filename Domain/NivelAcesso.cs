using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecclesia.Domain
{
    public class NivelAcesso : ModelBase
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
    }
}
