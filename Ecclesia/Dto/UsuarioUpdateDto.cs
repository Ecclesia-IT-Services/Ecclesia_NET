using Domain.Enum;

namespace Ecclesia.Api.Dto
{
    public class UsuarioUpdateDto
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public int NivelAcesso { get; set; }
        public int Usuario { get; set; }
        public string Status { get; set; }
    }
}
