namespace Ecclesia.Api.Dto
{
    public class OrganizacaoUpdateDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public int Usuario { get; set; }
        public string Status { get; set; }
    }
}
