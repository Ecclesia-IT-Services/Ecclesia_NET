namespace Ecclesia.Api.Dto
{
    public class ReuniaoUpdateDto
    {
        public int Id { get; set; }       
        public int Pregador { get; set; }
        public int QuantidadeParticipantes { get; set; }
        public int QuantidadeVisitantes { get; set; }
        public int QuantidadeCriancas { get; set; }
        public Decimal ValorOfertas { get; set; }
        public Decimal ValorOfertasEspeciais { get; set; }
        public Decimal ValorPrimicias { get; set; }
        public int Usuario { get; set; }
        public string Status { get; set; }
    }
}
