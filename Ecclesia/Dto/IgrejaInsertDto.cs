﻿namespace Ecclesia.Api.Dto
{
    public class IgrejaInsertDto
    {
        public string Nome { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public int Usuario{ get; set; }
    }
}

