namespace Ecclesia.Domain
{
    public class Cargo
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public int UsuarioCriacao { get; set; }
        public DateTime DataUltimaAlteracao { get; set; }
        public int UsuarioUltimaAlteracao { get; set; }
        public string Status { get; set; }
    }
}
