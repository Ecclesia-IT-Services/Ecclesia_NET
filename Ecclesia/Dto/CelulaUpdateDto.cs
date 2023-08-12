﻿namespace Ecclesia.Api.Dto
{
    public class CelulaUpdateDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Igreja { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public int Usuario { get; set; }
        public string Status { get; set; }
    }
}
