namespace Ecclesia.Api.Dto
{
    public class PessoaUpdateDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataIngresso { get; set; }
        public int Igreja { get; set; }
        public int Celula { get; set; }
        public int Cargo { get; set; }
        public DateTime DataBatismo { get; set; }
        public int Usuario { get; set; }
        public string Status { get; set; }
    }
}
