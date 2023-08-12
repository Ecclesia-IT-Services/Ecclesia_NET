namespace Ecclesia.Api.Dto
{
    public class ReuniaoInsertDto
    {
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
        public int Usuario { get; set; }
    }
}
