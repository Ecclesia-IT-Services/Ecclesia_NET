using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecclesia.Domain
{
    public class Reuniao : ModelBase
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int Igreja { get; set; }
        public int Celula { get; set; }
        public int Pregador { get; set; }
        public int QuantidadeParticipantes { get; set; }
        public int QuantidadeVisitantes { get; set; }
        public int QuantidadeCriancas { get; set; }
        public Decimal ValorOfertas { get; set; }
        public Decimal ValorOfertasEspeciais { get; set; }
        public Decimal ValorPrimicias { get; set; }
    }
}
