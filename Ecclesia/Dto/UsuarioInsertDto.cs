using Domain.Enum;

namespace Ecclesia.Api.Dto
{
    public class UsuarioInsertDto
    {
        public string Login { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public int NivelAcesso { get; set; }
        public int Usuario { get; set; }
    }
}
